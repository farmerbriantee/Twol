/*
   UDP Autosteer code for Teensy 4.1
   For Twol
   01 Feb 2022
   Like all Arduino code - copied from somewhere else :)
   So don't claim it as your own
*/

////////////////// User Settings /////////////////////////

//Distance before decreasing Max PWM
#define LOW_HIGH_DISTANCE 1.0

/*  PWM Frequency ->
     490hz (default) = 0
     122hz = 1
     3921hz = 2
*/
#define PWM_Frequency 0

/////////////////////////////////////////////

// if not in eeprom, overwrite
#define EEP_Ident 2400

//   ***********  Motor drive connections  **************888
//Connect ground only for cytron, Connect Ground and +5v for IBT2

//Dir1 for Cytron Dir, Both L and R enable for IBT2
#define DIR1_RL_ENABLE  4

//PWM1 for Cytron PWM, Left PWM for IBT2
#define PWM1_LPWM  2

//Not Connected for Cytron, Right PWM for IBT2
#define PWM2_RPWM  3

//--------------------------- Switch Input Pins ------------------------
#define STEERSW_PIN 32
#define WORKSW_PIN 34
#define REMOTE_PIN 37

//Define sensor pin for current or pressure sensor
#define CURRENT_SENSOR_PIN A17
#define PRESSURE_SENSOR_PIN A10

#define CONST_180_DIVIDED_BY_PI 57.2957795130823

#include <Wire.h>
#include <EEPROM.h>
#include "zADS1115.h"
ADS1115_lite adc(ADS1115_DEFAULT_ADDRESS);     // Use this for the 16-bit version ADS1115

#include <IPAddress.h>

#ifdef ARDUINO_TEENSY41
// ethernet
#include <NativeEthernet.h>
#include <NativeEthernetUdp.h>
#endif

//#ifdef ARDUINO_TEENSY41
////uint8_t Ethernet::buffer[200]; // udp send and receive buffer
//uint8_t toolSteerUdpData[UDP_TX_PACKET_MAX_SIZE];  // Buffer For Receiving UDP Data
//#endif

//loop time variables in microseconds
const uint16_t LOOP_TIME = 25;  //40Hz
uint32_t steerLoopLastTime = LOOP_TIME;
uint32_t currentTime = LOOP_TIME;

const uint16_t WATCHDOG_THRESHOLD = 100;
const uint16_t WATCHDOG_FORCE_VALUE = WATCHDOG_THRESHOLD + 2; // Should be greater than WATCHDOG_THRESHOLD
uint8_t watchdogTimer = WATCHDOG_FORCE_VALUE;

//Heart beat hello AgIO
//uint8_t helloFromIMU[] = { 128, 129, 121, 121, 5, 0, 0, 0, 0, 0, 71 };
uint8_t helloFromAutoSteer[] = { 0x80, 0x81, 226, 226, 5, 0, 0, 0, 0, 0, 71 };
int16_t helloSteerPosition = 0;

//fromAutoSteerData FD 253 - ActualSteerAngle*100 -5,6, SwitchByte-7, pwmDisplay-8
uint8_t PGN_230[] = {0x80,0x81, 226, 230, 8, 0, 0, 0, 0, 0,0,0,0, 0xCC };
int8_t PGN_230_Size = sizeof(PGN_230) - 1;

//EEPROM
int16_t EEread = 0;

uint8_t remoteSwitch = 0, workSwitch = 0, steerSwitch = 1, switchByte = 0;//Switches
uint8_t guidanceStatus = 0;//On Off
float gpsSpeed = 0;//speed sent as *10

float actuatorPositionPercent = 0;//actuator position as a percent of full scale -100 to 100 with zero in the middle

//from Twol
float toolXTE = 0; //tool XTE from Twol
float vehicleXTE = 0; //vehicle XTE from Twol
float toolCorrectionError = 0; //actual error based on position of tool.

int16_t manualPWM = 0; //manual PWM from Twol

int16_t actuatorPosition = 0; //from actuator sensor

//pwm variables
int16_t pwmDrive = 0, pwmDisplay = 0;
float pValue = 0;
float errorAbs = 0;
float highLowPerCentimeter = 0;

//Variables for settings - 0 is false
struct Setup {
    uint8_t IsRelayActiveHigh = 0;    // if zero, active low (default)
    uint8_t SingleInputAPOS = 1;
    uint8_t CytronDriver = 1;
    uint8_t invertAPOS = 0;
    uint8_t invertActuator = 0; // if zero, active low (default)
}; Setup boardConfig;               // 9 bytes

//Variables for settings
struct Tool_Settings {
    uint8_t Kp = 40;              // proportional gain
    uint8_t Ki = 0;
    uint8_t minPWM = 9;
    uint8_t lowPWM = 15;          // band of no action
    uint8_t highPWM = 60;         // max PWM value
    int16_t APOS_ZeroOffset = 0;
    uint8_t lowHighSetDistance = 10;
    uint8_t maxActuatorPosition = 30;
};  Tool_Settings pidSettings;      // 11 bytes

union _udpPacket {
    byte udpData[512];    // Incoming Buffer
    struct {
        uint16_t Twol_ID;
        byte MajorPGN;
        byte MinorPGN;
        byte data[508];
    };
};

_udpPacket udpPacket;

void steerConfigInit()
{
  //if (steerConfig.CytronDriver) 
  {
    pinMode(PWM2_RPWM, OUTPUT);
  }
}

void toolSettingsInit()
{
  // for PWM High to Low interpolator
  highLowPerCentimeter = ((float)(pidSettings.highPWM - pidSettings.minPWM)) / LOW_HIGH_DISTANCE;
}

void ToolsteerSetup()
{
    //PWM rate settings. Set them both the same!!!!
    /*  PWM Frequency ->
         490hz (default) = 0
         122hz = 1
         3921hz = 2
    */
    if (PWM_Frequency == 0)
    {
        analogWriteFrequency(PWM1_LPWM, 490);
        analogWriteFrequency(PWM2_RPWM, 490);
    }
    else if (PWM_Frequency == 1)
    {
        analogWriteFrequency(PWM1_LPWM, 122);
        analogWriteFrequency(PWM2_RPWM, 122);
    }
    else if (PWM_Frequency == 2)
    {
        analogWriteFrequency(PWM1_LPWM, 3921);
        analogWriteFrequency(PWM2_RPWM, 3921);
    }

    //keep pulled high and drag low to activate, noise free safe
    pinMode(WORKSW_PIN, INPUT_PULLUP);
    pinMode(STEERSW_PIN, INPUT_PULLUP);
    pinMode(REMOTE_PIN, INPUT_PULLUP);
    pinMode(DIR1_RL_ENABLE, OUTPUT);

    // Disable digital inputs for analog input pins
    pinMode(CURRENT_SENSOR_PIN, INPUT_DISABLE);
    pinMode(PRESSURE_SENSOR_PIN, INPUT_DISABLE);

    //set up communication
    Wire1.end();
    Wire1.begin();

    // Check ADC 
    if (adc.testConnection())
    {
        Serial.println("ADC Connecton OK");
    }
    else
    {
        Serial.println("ADC Connecton FAILED!");
    }

    //50Khz I2C
    //TWBR = 144;   //Is this needed?

    EEPROM.get(0, EEread);              // read identifier

    if (EEread != EEP_Ident)            // check on first start and write EEPROM
    {
        EEPROM.put(0, EEP_Ident);
        EEPROM.put(10, pidSettings);
        EEPROM.put(40, toolConfig);
        EEPROM.put(60, networkAddress);
    }
    else
    {
        EEPROM.get(10, pidSettings);     // read the Settings
        EEPROM.get(40, toolConfig);
        EEPROM.get(60, networkAddress);
    }

    toolSettingsInit();
    steerConfigInit();

    Serial.println("Autosteer running, waiting for Twol");
    // Autosteer Led goes Red if ADS1115 is found
    digitalWrite(AUTOSTEER_ACTIVE_LED, 0);
    digitalWrite(AUTOSTEER_STANDBY_LED, 1);

    adc.setSampleRate(ADS1115_REG_CONFIG_DR_128SPS); //128 samples per second
    adc.setGain(ADS1115_REG_CONFIG_PGA_6_144V);

}// End of Setup

void toolsteerLoop()
{
    // Loop triggers every 100 msec and sends back gyro heading, and roll, steer angle etc
    currentTime = systick_millis_count;

    if (currentTime - steerLoopLastTime >= LOOP_TIME)
    {
        steerLoopLastTime = currentTime;

        //If connection lost to Twol, the watchdog will count up and turn off steering
        if (watchdogTimer++ > 250) watchdogTimer = WATCHDOG_FORCE_VALUE;

        //read all the switches
        workSwitch = digitalRead(WORKSW_PIN);  // read work switch

        steerSwitch = digitalRead(STEERSW_PIN); //read auto steer enable switch open = 0n closed = Off

        remoteSwitch = digitalRead(REMOTE_PIN); //read auto steer enable switch open = 0n closed = Off

        switchByte = 0;
        switchByte |= (remoteSwitch << 2); //put remote in bit 2
        switchByte |= (steerSwitch << 1);   //put steerswitch status in bit 1 position
        switchByte |= workSwitch;

        //get steering position
        if (boardConfig.SingleInputAPOS)   //Single Input ADS
        {
            adc.setMux(ADS1115_REG_CONFIG_MUX_SINGLE_0);
            actuatorPosition = adc.getConversion();
            adc.triggerConversion();//ADS1115 Single Mode

            actuatorPosition = (actuatorPosition >> 1); //bit shift by 2  0 to 13610 is 0 to 5v
            helloSteerPosition = actuatorPosition - 6800;
        }
        else    //ADS1115 Differential Mode
        {
            adc.setMux(ADS1115_REG_CONFIG_MUX_DIFF_0_1);
            actuatorPosition = adc.getConversion();
            adc.triggerConversion();

            actuatorPosition = (actuatorPosition >> 1); //bit shift by 2  0 to 13610 is 0 to 5v
            helloSteerPosition = actuatorPosition - 6800;
        }

        //DETERMINE ACTUAL STEERING POSITION

		//convert position to percent actuator position = + - 100% of full scale, with zero in the middle.
        //  ***** make sure that negative steer angle makes a left turn and positive value is a right turn *****
        if (toolConfig.invertAPOS)
        {
            actuatorPosition = (actuatorPosition - 6800 - pidSettings.APOS_ZeroOffset);   // 1/2 of full scale
            actuatorPositionPercent = (float)(actuatorPosition) / -68;
        }
        else
        {
            actuatorPosition = (actuatorPosition - 6800 + pidSettings.APOS_ZeroOffset);   // 1/2 of full scale
            actuatorPositionPercent = (float)(actuatorPosition) / 68;
        }    

        if (watchdogTimer < WATCHDOG_THRESHOLD && guidanceStatus == 1)
        {
            //Enable H Bridge for IBT2, hyd aux, etc for cytron
            if (boardConfig.CytronDriver)
            {
                if (boardConfig.IsRelayActiveHigh)
                {
                    digitalWrite(PWM2_RPWM, 0);
                }
                else
                {
                    digitalWrite(PWM2_RPWM, 1);
                }
            }
            else digitalWrite(DIR1_RL_ENABLE, 1);

            toolCorrectionError = toolXTE;   //calculate the error
 
            calcSteeringPID();  //do the pid
            motorDrive();       //out to motors the pwm value
            // Autosteer Led goes GREEN if autosteering

            digitalWrite(AUTOSTEER_ACTIVE_LED, 1);
            digitalWrite(AUTOSTEER_STANDBY_LED, 0);
        }
        else
        {
            //we've lost the comm to Twol, or just stop request
            //Disable H Bridge for IBT2, hyd aux, etc for cytron
            if (boardConfig.CytronDriver)
            {
                if (boardConfig.IsRelayActiveHigh)
                {
                    digitalWrite(PWM2_RPWM, 1);
                }
                else
                {
                    digitalWrite(PWM2_RPWM, 0);
                }
            }
            else digitalWrite(DIR1_RL_ENABLE, 0); //IBT2

            pwmDrive = 0; //stop it
            motorDrive(); //out to motors the pwm value

            // Autosteer Led goes back to RED when autosteering is stopped
            digitalWrite(AUTOSTEER_STANDBY_LED, 1);
            digitalWrite(AUTOSTEER_ACTIVE_LED, 0);
        }
    } //end of timed loop

} // end of main loop

int currentRoll = 0;
int rollLeft = 0;
int steerLeft = 0;

// UDP Receive
void ReceiveUdp()
{
    // When ethernet is not running, return directly. parsePacket() will block when we don't
    if (!Ethernet_running)
    {
        return;
    }

    uint16_t len = Eth_udpToolSteer.parsePacket();

    // if (len > 0)
    // {
    //  Serial.print("ReceiveUdp: ");
    //  Serial.println(len);
    // }

    // Check for len > 4, because we check byte 0, 1, 3 and 3
    if (len > 4)
    {
        Eth_udpToolSteer.read(udpPacket.udpData, UDP_TX_PACKET_MAX_SIZE);

        if (udpPacket.Twol_ID == 0x8180 && udpPacket.MajorPGN == 0x7F) //Data
        {
            if (udpPacket.MinorPGN == PGNs::ToolSteer)  //tool steer data
            {
                //Bit 5,6   Tool XTE from Twol * 100 is sent
                toolXTE = ((float)(udpPacket.udpData[toolIDs::xteLo] | ((int8_t)udpPacket.udpData[toolIDs::xteHi]) << 8)) * 0.01; //low high bytes
                
                guidanceStatus = udpPacket.udpData[toolIDs::status];

                //Bit 8,9   Tool XTE from Twol * 100 is sent
                vehicleXTE = ((float)(udpPacket.udpData[toolIDs::xteVehLo] | ((int8_t)udpPacket.udpData[toolIDs::xteVehHi]) << 8)) * 0.01; //low high bytes

                gpsSpeed = ((float)(udpPacket.udpData[toolIDs::speed10])) * 0.1;

                //Bit 11,12   Tool XTE from Twol * 100 is sent
                manualPWM = ((float)(udpPacket.udpData[toolIDs::manualLo] | ((int8_t)udpPacket.udpData[toolIDs::manualHi]) << 8)) * 0.01; //low high bytes

                //Serial.print("steerAngleSetPoint: ");//Serial.println(steerAngleSetPoint); //Serial.println(gpsSpeed);

                //if ((bitRead(guidanceStatus, 0) == 0) || (gpsSpeed < 0.1) || (steerSwitch == 1))
                if ( (bitRead(guidanceStatus, 0) == 0) || (gpsSpeed < 0.1) )
                    {
                    watchdogTimer = WATCHDOG_FORCE_VALUE; //turn off steering motor
                }
                else          //valid conditions to turn on autosteer
                {
                    watchdogTimer = 0;  //reset watchdog
                }

                //----------------------------------------------------------------------------
                //Serial Send to Twol
                int16_t sa;
                sa = (int16_t)(actuatorPositionPercent * 100);
                
                PGN_230[5] = (uint8_t)sa;
                PGN_230[6] = sa >> 8;

                // heading
                PGN_230[7] = (uint8_t)9999;
                PGN_230[8] = 9999 >> 8;

                // roll
                PGN_230[9] = (uint8_t)8888;
                PGN_230[10] = 8888 >> 8;

                PGN_230[11] = switchByte;
                PGN_230[12] = (uint8_t)pwmDisplay;

                //checksum
                int16_t CK_A = 0;
                for (uint8_t i = 2; i < PGN_230_Size; i++)
                    CK_A = (CK_A + PGN_230[i]);

                PGN_230[PGN_230_Size] = CK_A;

                //off to Twol
                SendUdp(PGN_230, sizeof(PGN_230), Eth_ipDestination, portDestination);

                //Serial.println(steerAngleActual);
                //--------------------------------------------------------------------------
            }

            //steer settings
            else if (udpPacket.MinorPGN == PGNs::ToolSteerSettings)
            {
                // gainP = 5;
                // integral = 6;
                // minPWM = 7;
                // highPWM = 8;
                // countsPerDegree = 9;
                // wasOffsetLo = 10;
                // wasOffsetHi = 11;
                // ackerman = 12;

                //PID values
                pidSettings.Kp = ((float)udpPacket.udpData[toolSteerIDs::gainP]);   // read Kp from Twol

                pidSettings.Ki = udpPacket.udpData[toolSteerIDs::integral]; // read high pwm

                pidSettings.minPWM = udpPacket.udpData[toolSteerIDs::minPWM]; //read the minimum amount of PWM for instant on

                float temp = (float)pidSettings.minPWM * 1.2;
                pidSettings.lowPWM = (byte)temp;

                pidSettings.highPWM = udpPacket.udpData[toolSteerIDs::highPWM]; // read high pwm

                pidSettings.steerSensorCounts = udpPacket.udpData[toolSteerIDs::countsPerDegree]; //sent as setting displayed in Twol

                pidSettings.APOS_ZeroOffset = udpPacket.udpData[toolSteerIDs::wasOffsetLo];  //read was zero offset Lo
                pidSettings.APOS_ZeroOffset |= (udpPacket.udpData[toolSteerIDs::wasOffsetHi] << 8);  //read was zero offset Hi

                pidSettings.AckermanFix = (float)udpPacket.udpData[toolSteerIDs::ackerman] * 0.01;

                //crc
                //autoSteerUdpData[13];

                //store in EEPROM
                EEPROM.put(10, pidSettings);

                // Re-Init steer settings
                toolSettingsInit();
            }

            else if (udpPacket.MinorPGN == PGNs::ToolSteerConfig)  //Tool Steer Config
            {
                toolConfig.invertAPOS = udpPacket.udpData[toolSteerConfig::invertWAS];

                toolConfig.invertActuator = udpPacket.udpData[toolSteerConfig::invertSteer];

                toolConfig.maxActuatorPosition = udpPacket.udpData[toolSteerConfig::maxSteerAngle];

                //for steering or sliding, not sure if it is needes
                toolConfig.isSteer = udpPacket.udpData[toolSteerConfig::isSteer];
                
                EEPROM.put(40, boardConfig);

                // Re-Init
                steerConfigInit();

            }//end FB
            else if (udpPacket.MinorPGN == PGNs::AgIOHello) // Hello from AgIO
            {
                int16_t sa = (int16_t)(actuatorPositionPercent * 100);

                helloFromAutoSteer[5] = (uint8_t)sa;
                helloFromAutoSteer[6] = sa >> 8;

                helloFromAutoSteer[7] = (uint8_t)helloSteerPosition;
                helloFromAutoSteer[8] = helloSteerPosition >> 8;
                helloFromAutoSteer[9] = switchByte;

                SendUdp(helloFromAutoSteer, sizeof(helloFromAutoSteer), Eth_ipDestination, portDestination);
            }

            else if (udpPacket.MinorPGN == PGNs::SubnetChange)
            {
                //make really sure this is the subnet pgn
                if (udpPacket.udpData[4] == 5 && udpPacket.udpData[5] == 201 && udpPacket.udpData[6] == 201)
                {
                    networkAddress.ipOne = udpPacket.udpData[7];
                    networkAddress.ipTwo = udpPacket.udpData[8];
                    networkAddress.ipThree = udpPacket.udpData[9];

                    //save in EEPROM and restart
                    EEPROM.put(60, networkAddress);
                    SCB_AIRCR = 0x05FA0004; //Teensy Reset
                }
            }//end 201

            //whoami
            else if (udpPacket.MinorPGN == PGNs::SubnetRequest)
            {
                //make really sure this is the reply pgn
                if (udpPacket.udpData[4] == 3 && udpPacket.udpData[5] == 202 && udpPacket.udpData[6] == 202)
                {
                    IPAddress rem_ip = Eth_udpToolSteer.remoteIP();

                    //hello from AgIO
                    uint8_t scanReply[] = { 128, 129, Eth_myip[3], 203, 7,
                        Eth_myip[0], Eth_myip[1], Eth_myip[2], Eth_myip[3],
                        rem_ip[0],rem_ip[1],rem_ip[2], 23 };

                    //checksum
                    int16_t CK_A = 0;
                    for (uint8_t i = 2; i < sizeof(scanReply) - 1; i++)
                    {
                        CK_A = (CK_A + scanReply[i]);
                    }
                    scanReply[sizeof(scanReply) - 1] = CK_A;

                    static uint8_t ipDest[] = { 255,255,255,255 };
                    //uint16_t portDest = 19999; //Twol port that listens

                    //off to Twol
                    SendUdp(scanReply, sizeof(scanReply), ipDest, portDestination);
                }
            }
        } //end if 80 81 7F
    }
}

void SendUdp(uint8_t *data, uint8_t datalen, IPAddress dip, uint16_t dport)
{
  Eth_udpToolSteer.beginPacket(dip, dport);
  Eth_udpToolSteer.write(data, datalen);
  Eth_udpToolSteer.endPacket();
}
