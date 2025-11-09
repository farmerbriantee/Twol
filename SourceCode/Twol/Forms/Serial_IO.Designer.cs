using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twol
{
    public partial class FormGPS
    {
        public bool lastHelloGPS, lastHelloAutoSteer, lastHelloMachine, lastHelloIMU, lastHelloGPSTool, lastHelloGPSOutSerial;

        private void DoHelloAlarmLogic()
        {
            bool currentHello;

            if (Settings.IO.setMod_isMachineConnected)
            {
                currentHello = traffic.helloFromMachine < 3;

                if (currentHello != lastHelloMachine)
                {
                    if (currentHello) btnMachine.BackColor = Color.PaleGreen;
                    else btnMachine.BackColor = Color.Red;
                    lastHelloMachine = currentHello;
                    panel_IO.Visible = true;
                    panel_IO.BringToFront();
                }
            }

            if (Settings.IO.setMod_isSteerConnected)
            {
                currentHello = traffic.helloFromAutoSteer < 3;

                if (currentHello != lastHelloAutoSteer)
                {
                    if (currentHello) btnSteer.BackColor = Color.PaleGreen;
                    else btnSteer.BackColor = Color.Red;
                    lastHelloAutoSteer = currentHello;
                    panel_IO.Visible = true;
                    panel_IO.BringToFront();
                }
            }

            if (Settings.IO.setMod_isIMUConnected)
            {
                currentHello = traffic.helloFromIMU < 3;

                if (currentHello != lastHelloIMU)
                {
                    if (currentHello) btnIMU.BackColor = Color.PaleGreen;
                    else btnIMU.BackColor = Color.Red;
                    lastHelloIMU = currentHello;
                    panel_IO.Visible = true;
                    panel_IO.BringToFront();
                }
            }

            currentHello = traffic.cntrGPSOut != 0;

            if (currentHello != lastHelloGPS)
            {
                if (currentHello)
                    btnGPS.BackColor = Color.PaleGreen;
                else
                    btnGPS.BackColor = Color.Red;

                lastHelloGPS = currentHello;
                panel_IO.Visible = true;
                panel_IO.BringToFront();
            }

            currentHello = traffic.cntrGPSOutTool != 0;

            if (currentHello != lastHelloGPSTool)
            {
                if (currentHello) btnGPSTool.BackColor = Color.PaleGreen;
                else btnGPSTool.BackColor = Color.Red;
                lastHelloGPSTool = currentHello;
                panel_IO.Visible = true;
                panel_IO.BringToFront();
            }

            //currentHello = traffic.cntrGPS_OutSerial != 0;

            //if (currentHello != lastHelloGPSOutSerial)
            //{
            //    if (currentHello) btnGPS_Out.BackColor = Color.LimeGreen;
            //    else btnGPS_Out.BackColor = Color.Red;
            //    lastHelloGPSOutSerial = currentHello;
            //}

        }

        private void DoTraffic()
        {
            traffic.helloFromMachine++;
            traffic.helloFromAutoSteer++;
            traffic.helloFromIMU++;

            if (panel_IO.Visible)
            {
                lblFromGPS.Text = traffic.cntrGPSOut == 0 ? "---" : ((traffic.cntrGPSOut >> 1)).ToString();
                lblFromGPSTool.Text = traffic.cntrGPSOutTool == 0 ? "---" : ((traffic.cntrGPSOutTool >> 1)).ToString();
                //lblGPSOutSerial.Text = traffic.cntrGPS_OutSerial == 0 ? "---" : ((traffic.cntrGPS_OutSerial)).ToString();

                //lblSlowGPSOut.Text = "";

                //lblCurentLon.Text = pnGPS.longitude.ToString("N7");
                //lblCurrentLat.Text = pnGPS.latitude.ToString("N7");
            }

            //reset all counters
            traffic.cntrGPSOut = 0;
            traffic.cntrGPSOutTool = 0;
            traffic.cntrGPS_OutSerial = 0;
        }

        private int totalHeaderByteCount = 5;

        public static int baudRateIMU = 115200;
        public static int baudRateSteerModule = 38400;
        public static int baudRateMachineModule = 115200;

        //used to decide to autoconnect section arduino this run
        public string recvGPSSentence = "GPS";
        public string recvGPS2Sentence = "GPS2";
        public string recvIMUSentence = "IMU";
        public string recvSteerModuleSentence = "Module 1";
        public string recvMachineModuleSentence = "Module 2";

        public bool isGPSCommOpen = false;

        public byte checksumSent = 0;
        public byte checksumRecd = 0;

        //serial port gps is connected to
        public SerialPort spGPS = new SerialPort(Settings.IO.setPort_portNameGPS, Settings.IO.setPort_baudRateGPS, Parity.None, 8, StopBits.One);

        //serial port gps is connected to
        public static SerialPort spGPSOut = new SerialPort(Settings.IO.setPort_portNameGPSOut, Settings.IO.setPort_baudRateGPSOut, Parity.None, 8, StopBits.One);

        //serial port gps2 is connected to
        public SerialPort spGPS2 = new SerialPort(Settings.IO.setPort_portNameGPS2, Settings.IO.setPort_baudRateGPS2, Parity.None, 8, StopBits.One);

        //serial port gps is connected to
        public SerialPort spRtcm = new SerialPort(Settings.IO.setPort_portNameRtcm, Settings.IO.setPort_baudRateRtcm, Parity.None, 8, StopBits.One);

        //serial port Arduino is connected to
        public SerialPort spIMU = new SerialPort(Settings.IO.setPort_portNameIMU, baudRateIMU, Parity.None, 8, StopBits.One);

        //serial port Arduino is connected to
        public SerialPort spSteerModule = new SerialPort(Settings.IO.setPort_portNameSteer, baudRateSteerModule, Parity.None, 8, StopBits.One);

        //serial port Arduino is connected to
        public SerialPort spMachineModule = new SerialPort(Settings.IO.setPort_portNameMachine, baudRateMachineModule, Parity.None, 8, StopBits.One);

        //serial port Ardiuno is connected to
        //public SerialPort spModule3 = new SerialPort(portNameModule3, baudRateModule3, Parity.None, 8, StopBits.One);

        //lists for parsing incoming bytes
        private byte[] pgnSteerModule = new byte[22];
        private byte[] pgnMachineModule = new byte[22];
        //private byte[] pgnModule3 = new byte[262];
        private byte[] pgnIMU = new byte[22];

        private void ReconnectSerialPorts()
        {
            //GPS Port
            if (Settings.IO.setPort_wasGPSConnected && !spGPS.IsOpen)
            {
                OpenGPSPort();
            }
            //GPS Out Port
            if (Settings.IO.setPort_wasGPSOutConnected && !spGPSOut.IsOpen)
            {
                OpenGPSOutPort();
            }
            //RTCM Port
            if (Settings.IO.setPort_wasRtcmConnected && !spRtcm.IsOpen)
            {
                OpenRtcmPort();
            }
            //IMU Port
            if (Settings.IO.setPort_wasIMUConnected && !spIMU.IsOpen)
            {
                OpenIMUPort();
            }
            //Steer Module Port
            if (Settings.IO.setPort_wasSteerModuleConnected && !spSteerModule.IsOpen)
            {
                OpenSteerModulePort();
            }
            //Machine Module Port
            if (Settings.IO.setPort_wasMachineModuleConnected && !spMachineModule.IsOpen)
            {
                OpenMachineModulePort();
            }
        }

        private void SettingsCommunicationGPS()
        {
            isGPSCommOpen = true;

            using (FormCommSetGPS form = new FormCommSetGPS(this))
            {
                form.ShowDialog(this);
            }
            isGPSCommOpen = false;
        }

        private void RescanPorts()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();

            //if (ports.Length == 0)
            //{
            //    lblSerialPorts.Text = "None";
            //}
            //else
            //{
            //    lblSerialPorts.Text = "";
            //    for (int i = 0; i < ports.Length; i++)
            //    {
            //        lblSerialPorts.Text += ports[i] + " ";
            //    }
            //}
        }

        private void btnBringUpCommSettings_Click(object sender, EventArgs e)
        {
            SettingsCommunicationGPS();
            RescanPorts();
        }

        #region IMUSerialPort //--------------------------------------------------------------------
        private void ReceiveIMUPort(byte[] data)
        {
            //SendToLoopBackMessageTWOL(Data);
            try
            {
                int length = data.Length;
                if (length < 2) return;

                if (data[0] == 0x80 && data[1] == 0x81)
                {

                    switch (data[3])
                    {
                        case 121:
                            {
                                if (length == 11) traffic.helloFromIMU = 0;
                                break;
                            }

                        case 211:
                            {
                                if (length != 12) break;
                                if (ahrs.imuRoll > 2500 || ahrs.imuRoll < -2500) ahrs.imuRoll = 0;
                                ahrs.imuHeading = (Int16)((data[6] << 8) + data[5]) * 0.1;

                                double rollK = (Int16)((data[8] << 8) + data[7]);
                                if (Settings.Vehicle.setIMU_invertRoll) rollK *= -0.01;
                                else rollK *= 0.01;
                                rollK -= Settings.Vehicle.setIMU_rollZero;
                                ahrs.imuRoll = ahrs.imuRoll * Settings.Vehicle.setIMU_rollFilter + rollK * (1 - Settings.Vehicle.setIMU_rollFilter);

                                ahrs.angVel = (Int16)((data[10] << 8) + data[9]);
                                break;
                            }
                    }
                }
            }
            catch { }
        }

        //Send machine info out to machine board
        public void SendIMUPort(byte[] items, int numItems)
        {
            //Tell Arduino to turn section on or off accordingly
            if (spIMU.IsOpen)
            {
                try
                {
                    spIMU.Write(items, 0, numItems);
                }
                catch (Exception)
                {
                    CloseIMUPort();
                }
            }
        }

        //open the Arduino serial port
        public void OpenIMUPort()
        {
            if (!spIMU.IsOpen)
            {
                spIMU.PortName = Settings.IO.setPort_portNameIMU;
                spIMU.BaudRate = baudRateIMU;
                spIMU.DataReceived += sp_DataReceivedIMU;
                spIMU.DtrEnable = true;
                spIMU.RtsEnable = true;
            }

            try { spIMU.Open(); }
            catch (Exception e)
            {
                Log.EventWriter("Opening Machine Port" + e.ToString());

                MessageBox.Show(e.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No Arduino Port Active");

                Settings.IO.setPort_wasIMUConnected = false;
            }

            if (spIMU.IsOpen)
            {
                //short delay for the use of mega2560, it is working in debugmode with breakpoint
                System.Threading.Thread.Sleep(500); // 500 was not enough

                spIMU.DiscardOutBuffer();
                spIMU.DiscardInBuffer();

                Settings.IO.setPort_wasIMUConnected = true;
                //lblIMUComm.Text = Settings.IO.setPort_portNameIMU;
            }
        }

        //close the machine port
        public void CloseIMUPort()
        {
            if (spIMU.IsOpen)
            {
                spIMU.DataReceived -= sp_DataReceivedIMU;
                try
                {
                    spIMU.Close();
                    byte[] imuClose = new byte[] { 0x80, 0x81, 0x7C, 0xD4, 2, 1, 0, 0xCC };

                    //tell AgOpenGPS IMU is disconnected
                    //SendToLoopBackMessageTWOL(imuClose);
                }

                catch (Exception e)
                {
                    Log.EventWriter("Closing Machine Serial Port" + e.ToString());
                    MessageBox.Show(e.Message, "Connection already terminated??");
                }

                Settings.IO.setPort_wasIMUConnected = false;

                spIMU.Dispose();
            }

            else
            {
                byte[] imuClose = new byte[] { 0x80, 0x81, 0x7C, 0xD4, 2, 1, 0, 0xCC };

                //tell AgOpenGPS IMU is disconnected
                //SendToLoopBackMessageTWOL(imuClose);
                Settings.IO.setPort_wasIMUConnected = false;
            }

            Settings.IO.setPort_wasIMUConnected = false;
            //lblIMUComm.Text = "---";
        }

        private void sp_DataReceivedIMU(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (spIMU.IsOpen)
            {
                byte[] ByteList;
                ByteList = pgnIMU;

                try
                {
                    if (spIMU.BytesToRead > 100)
                    {
                        spIMU.DiscardInBuffer();
                        return;
                    }

                    byte a;

                    int aas = spIMU.BytesToRead;

                    for (int i = 0; i < aas; i++)
                    {
                        a = (byte)spIMU.ReadByte();

                        switch (ByteList[21])
                        {
                            case 0: //find 0x80
                                {
                                    if (a == 128) ByteList[ByteList[21]++] = a;
                                    else ByteList[21] = 0;
                                    break;
                                }

                            case 1:  //find 0x81   
                                {
                                    if (a == 129) ByteList[ByteList[21]++] = a;
                                    else
                                    {
                                        if (a == 181)
                                        {
                                            ByteList[21] = 0;
                                            ByteList[ByteList[21]++] = a;
                                        }
                                        else ByteList[21] = 0;
                                    }
                                    break;
                                }

                            case 2: //Source Address (7F)
                                {
                                    if (a < 128 && a > 120)
                                        ByteList[ByteList[21]++] = a;
                                    else ByteList[21] = 0;
                                    break;
                                }

                            case 3: //PGN ID
                                {
                                    ByteList[ByteList[21]++] = a;
                                    break;
                                }

                            case 4: //Num of data bytes
                                {
                                    ByteList[ByteList[21]++] = a;
                                    break;
                                }

                            default: //Data load and Checksum
                                {
                                    if (ByteList[21] > 4)
                                    {
                                        int length = ByteList[4] + totalHeaderByteCount;
                                        if ((ByteList[21]) < length)
                                        {
                                            ByteList[ByteList[21]++] = a;
                                            break;
                                        }
                                        else
                                        {
                                            //crc
                                            int CK_A = 0;
                                            for (int j = 2; j < length; j++)
                                            {
                                                CK_A = CK_A + ByteList[j];
                                            }

                                            //if checksum matches finish and update main thread
                                            if (a == (byte)(CK_A))
                                            {
                                                length++;
                                                ByteList[ByteList[21]++] = (byte)CK_A;
                                                BeginInvoke((MethodInvoker)(() => ReceiveIMUPort(ByteList.Take(length).ToArray())));
                                            }

                                            //clear out the current pgn
                                            ByteList[21] = 0;
                                            return;
                                        }
                                    }

                                    break;
                                }
                        }
                    }
                }
                catch
                {
                    ByteList[21] = 0;
                }
            }
        }
        #endregion ----------------------------------------------------------------

        #region SteerModuleSerialPort //---------------------------------------------------
        private void ReceiveSteerModulePort(byte[] data)
        {
            try
            {
                int length = data.Length;
                if (length < 2) return;

                if (data[0] == 0x80 && data[1] == 0x81)
                {

                    switch (data[3])
                    {
                        case 253:
                            {
                                if (length != 14) break;
                                mc.actualSteerAngleChart = (Int16)((data[6] << 8) + data[5]);
                                mc.actualSteerAngleDegrees = (double)mc.actualSteerAngleChart * 0.01;

                                double head253 = (Int16)((data[8] << 8) + data[7]);
                                if (head253 != 9999) ahrs.imuHeading = head253 * 0.1;

                                double rollK = (Int16)((data[10] << 8) + data[9]);
                                if (rollK != 8888)
                                {
                                    if (Settings.Vehicle.setIMU_invertRoll) rollK *= -0.1;
                                    else rollK *= 0.1;
                                    rollK -= Settings.Vehicle.setIMU_rollZero;
                                    ahrs.imuRoll = ahrs.imuRoll * Settings.Vehicle.setIMU_rollFilter + rollK * (1 - Settings.Vehicle.setIMU_rollFilter);
                                }

                                mc.workSwitchHigh = (data[11] & 1) == 1;
                                mc.steerSwitchHigh = (data[11] & 2) == 2;
                                steerModuleConnectedCounter = 0;
                                mc.pwmDisplay = data[12];
                                break;
                            }

                        case 250:
                            {
                                if (length != 14) break;
                                mc.sensorData = data[5];
                                break;
                            }

                        case 126:
                            {
                                if (length == 11) traffic.helloFromAutoSteer = 0;
                                break;
                            }
                    }
                }
            }

            catch { }

        }

        //Send machine info out to machine board
        public void SendSteerModulePort(byte[] items, int numItems)
        {
            // Tell Arduino to turn section on or off accordingly
            if (spSteerModule.IsOpen)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        spSteerModule.Write(items, 0, numItems);
                    }
                    catch (Exception ex)
                    {
                        Log.EventWriter("Catch - > Serial Steer module disconnect: " + ex.ToString());
                        CloseSteerModulePort();
                    }
                });
            }
        }

        //open the Arduino serial port
        public void OpenSteerModulePort()
        {
            if (!spSteerModule.IsOpen)
            {
                spSteerModule.PortName = Settings.IO.setPort_portNameSteer;
                spSteerModule.BaudRate = baudRateSteerModule;
                spSteerModule.DataReceived += sp_DataReceivedSteerModule;
                spSteerModule.DtrEnable = true;
                spSteerModule.RtsEnable = true;
            }

            try
            {
                spSteerModule.Open();
                //short delay for the use of mega2560, it is working in debugmode with breakpoint
                System.Threading.Thread.Sleep(1000); // 500 was not enough

            }
            catch (Exception e)
            {
                Log.EventWriter("Opening Machine Port" + e.ToString());

                MessageBox.Show(e.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No Arduino Port Active");

                Settings.IO.setPort_wasSteerModuleConnected = false;

            }

            if (spSteerModule.IsOpen)
            {
                spSteerModule.DiscardOutBuffer();
                spSteerModule.DiscardInBuffer();

                Settings.IO.setPort_wasSteerModuleConnected = true;
                //lblMod1Comm.Text = Settings.IO.setPort_portNameSteer;
            }
        }

        //close the machine port
        public void CloseSteerModulePort()
        {
            if (spSteerModule.IsOpen)
            {
                spSteerModule.DataReceived -= sp_DataReceivedSteerModule;
                try { spSteerModule.Close(); }
                catch (Exception e)
                {
                    Log.EventWriter("Closing Machine Serial Port" + e.ToString());
                    MessageBox.Show(e.Message, "Connection already terminated??");
                }

                Settings.IO.setPort_wasSteerModuleConnected = false;

                spSteerModule.Dispose();
            }

            Settings.IO.setPort_wasSteerModuleConnected = false;
            //lblMod1Comm.Text = "---";
        }

        private void sp_DataReceivedSteerModule(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (spSteerModule.IsOpen)
            {
                byte[] ByteList;
                ByteList = pgnSteerModule;

                try
                {
                    if (spSteerModule.BytesToRead > 100)
                    {
                        spSteerModule.DiscardInBuffer();
                        return;
                    }

                    byte a;

                    int aas = spSteerModule.BytesToRead;

                    for (int i = 0; i < aas; i++)
                    {
                        //traffic.cntrIMUIn++;

                        a = (byte)spSteerModule.ReadByte();

                        switch (ByteList[21])
                        {
                            case 0: //find 0x80
                                {
                                    if (a == 128) ByteList[ByteList[21]++] = a;
                                    else ByteList[21] = 0;
                                    break;
                                }

                            case 1:  //find 0x81   
                                {
                                    if (a == 129) ByteList[ByteList[21]++] = a;
                                    else
                                    {
                                        if (a == 181)
                                        {
                                            ByteList[21] = 0;
                                            ByteList[ByteList[21]++] = a;
                                        }
                                        else ByteList[21] = 0;
                                    }
                                    break;
                                }

                            case 2: //Source Address (7F)
                                {
                                    if (a < 128 && a > 120)
                                        ByteList[ByteList[21]++] = a;
                                    else ByteList[21] = 0;
                                    break;
                                }

                            case 3: //PGN ID
                                {
                                    ByteList[ByteList[21]++] = a;
                                    break;
                                }

                            case 4: //Num of data bytes
                                {
                                    ByteList[ByteList[21]++] = a;
                                    break;
                                }

                            default: //Data load and Checksum
                                {
                                    if (ByteList[21] > 4)
                                    {
                                        int length = ByteList[4] + totalHeaderByteCount;
                                        if ((ByteList[21]) < length)
                                        {
                                            ByteList[ByteList[21]++] = a;
                                            break;
                                        }
                                        else
                                        {
                                            //crc
                                            int CK_A = 0;
                                            for (int j = 2; j < length; j++)
                                            {
                                                CK_A = CK_A + ByteList[j];
                                            }

                                            //if checksum matches finish and update main thread
                                            if (a == (byte)(CK_A))
                                            {
                                                length++;
                                                ByteList[ByteList[21]++] = (byte)CK_A;
                                                BeginInvoke((MethodInvoker)(() => ReceiveSteerModulePort(ByteList.Take(length).ToArray())));
                                            }

                                            //clear out the current pgn
                                            ByteList[21] = 0;
                                            return;
                                        }
                                    }

                                    break;
                                }
                        }
                    }
                }
                catch (Exception)
                {
                    ByteList[21] = 0;
                }
            }
        }
        #endregion ----------------------------------------------------------------

        #region MachineModuleSerialPort // Machine Port -----------------------------------

        private void ReceiveMachineModulePort(byte[] data)
        {
            try
            {
                int length = data.Length;
                if (length < 2) return;

                if (data[0] == 0x80 && data[1] == 0x81)
                {

                    switch (data[3])
                    {
                        case 224:
                            {
                                Settings.Tool.setNozz.unitsApplied = (Int16)((data[6] << 8) + data[5]) * 0.1;
                                nozz.rateActual = (Int16)((data[8] << 8) + data[7]);
                                nozz.pressureActual = data[9];
                                nozz.isFlowingFlag = data[10] != 0;
                                nozz.pwmDriveActual = data[11];
                                if (data[12] == 0) nozz.pwmDriveActual *= -1;
                                nozz.frequency = (Int16)((data[14] << 8) + data[13]);
                                break;
                            }

                        case 123:
                            {
                                if (length == 11) traffic.helloFromMachine = 0;
                                break;
                            }
                    }
                }
            }
            catch { }

        }

        //Send machine info out to machine board
        public void SendMachineModulePort(byte[] items, int numItems)
        {
            if (spMachineModule.IsOpen)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        spMachineModule.Write(items, 0, numItems);
                    }
                    catch (Exception ex)
                    {
                        Log.EventWriter("Catch - > Serial Machine module disconnect: " + ex.ToString());
                        CloseMachineModulePort();
                    }
                });
            }
        }

        //open the Arduino serial port
        public void OpenMachineModulePort()
        {
            if (!spMachineModule.IsOpen)
            {
                spMachineModule.PortName = Settings.IO.setPort_portNameMachine;
                spMachineModule.BaudRate = baudRateMachineModule;
                spMachineModule.DataReceived += sp_DataReceivedMachineModule;
                spMachineModule.DtrEnable = true;
                spMachineModule.RtsEnable = true;
            }

            try
            {
                spMachineModule.Open();
                //short delay for the use of mega2560, it is working in debugmode with breakpoint
                System.Threading.Thread.Sleep(1000); // 500 was not enough

            }
            catch (Exception e)
            {
                Log.EventWriter("Opening Machine Port" + e.ToString());

                MessageBox.Show(e.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No Arduino Port Active");

                Settings.IO.setPort_wasMachineModuleConnected = false;
            }

            if (spMachineModule.IsOpen)
            {
                spMachineModule.DiscardOutBuffer();
                spMachineModule.DiscardInBuffer();

                Settings.IO.setPort_wasMachineModuleConnected = true;
                //lblMod2Comm.Text = Settings.IO.setPort_portNameMachine;
            }
        }

        //close the machine port
        public void CloseMachineModulePort()
        {
            if (spMachineModule.IsOpen)
            {
                spMachineModule.DataReceived -= sp_DataReceivedMachineModule;
                try { spMachineModule.Close(); }
                catch (Exception e)
                {
                    Log.EventWriter("Closing Machine Serial Port" + e.ToString());
                    MessageBox.Show(e.Message, "Connection already terminated??");
                }

                Settings.IO.setPort_wasMachineModuleConnected = false;

                spMachineModule.Dispose();
            }

            Settings.IO.setPort_wasMachineModuleConnected = false;
            //lblMod2Comm.Text = "---";
        }

        private void sp_DataReceivedMachineModule(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (spMachineModule.IsOpen)
            {
                byte[] ByteList;
                ByteList = pgnMachineModule;

                try
                {
                    if (spMachineModule.BytesToRead > 100)
                    {
                        spMachineModule.DiscardInBuffer();
                        return;
                    }

                    byte a;

                    int aas = spMachineModule.BytesToRead;

                    for (int i = 0; i < aas; i++)
                    {
                        //traffic.cntrIMUIn++;

                        a = (byte)spMachineModule.ReadByte();

                        switch (ByteList[21])
                        {
                            case 0: //find 0x80
                                {
                                    if (a == 128) ByteList[ByteList[21]++] = a;
                                    else ByteList[21] = 0;
                                    break;
                                }

                            case 1:  //find 0x81   
                                {
                                    if (a == 129) ByteList[ByteList[21]++] = a;
                                    else
                                    {
                                        if (a == 181)
                                        {
                                            ByteList[21] = 0;
                                            ByteList[ByteList[21]++] = a;
                                        }
                                        else ByteList[21] = 0;
                                    }
                                    break;
                                }

                            case 2: //Source Address (7F)
                                {
                                    if (a < 128 && a > 120)
                                        ByteList[ByteList[21]++] = a;
                                    else ByteList[21] = 0;
                                    break;
                                }

                            case 3: //PGN ID
                                {
                                    ByteList[ByteList[21]++] = a;
                                    break;
                                }

                            case 4: //Num of data bytes
                                {
                                    ByteList[ByteList[21]++] = a;
                                    break;
                                }

                            default: //Data load and Checksum
                                {
                                    if (ByteList[21] > 4)
                                    {
                                        int length = ByteList[4] + totalHeaderByteCount;
                                        if ((ByteList[21]) < length)
                                        {
                                            ByteList[ByteList[21]++] = a;
                                            break;
                                        }
                                        else
                                        {
                                            //crc
                                            int CK_A = 0;
                                            for (int j = 2; j < length; j++)
                                            {
                                                CK_A = CK_A + ByteList[j];
                                            }

                                            //if checksum matches finish and update main thread
                                            if (a == (byte)(CK_A))
                                            {
                                                ByteList[ByteList[21]++] = (byte)CK_A;
                                                length++;
                                                BeginInvoke((MethodInvoker)(() => ReceiveMachineModulePort(ByteList.Take(length).ToArray())));
                                            }

                                            //clear out the current pgn
                                            ByteList[21] = 0;
                                            return;
                                        }
                                    }

                                    break;
                                }
                        }
                    }
                }
                catch (Exception)
                {
                    ByteList[21] = 0;
                }
            }
        }

        #endregion

        #region SerialPortGPS //-----------------------------------------------------------

        public void SendGPSPort(byte[] data)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    if (spRtcm.IsOpen)
                    {
                        spRtcm.Write(data, 0, data.Length);
                    }
                    else if (spGPS.IsOpen)
                    {
                        spGPS.Write(data, 0, data.Length);
                    }
                }
                catch (Exception)
                {
                }
            });
        }

        public void OpenGPSPort()
        {

            if (spGPS.IsOpen)
            {
                //close it first
                CloseGPSPort();
            }

            if (!spGPS.IsOpen)
            {
                spGPS.PortName = Settings.IO.setPort_portNameGPS;
                spGPS.BaudRate = Settings.IO.setPort_baudRateGPS;
                spGPS.DataReceived += sp_DataReceivedGPS;
                spGPS.WriteTimeout = 1000;
            }

            try { spGPS.Open(); }
            catch (Exception ex)
            {
                Log.EventWriter("Catch - > Serial GPS Open Fail: " + ex.ToString());

            }

            if (spGPS.IsOpen)
            {
                //discard any stuff in the buffers
                spGPS.DiscardOutBuffer();
                spGPS.DiscardInBuffer();

                Settings.IO.setPort_wasGPSConnected = true;

                //lblGPS1Comm.Text = Settings.IO.setPort_portNameGPS;
            }
        }
        public void CloseGPSPort()
        {
            //if (sp.IsOpen)
            {
                //spGPS.DataReceived -= sp_DataReceivedGPS;
                try { spGPS.Close(); }
                catch (Exception e)
                {
                    Log.EventWriter("Closing GPS Port" + e.ToString());
                    MessageBox.Show(e.Message, "Connection already terminated?");
                }

                //update port status labels
                //stripPortGPS.Text = " * * " + baudRateGPS.ToString();
                //stripPortGPS.ForeColor = Color.ForestGreen;
                //stripOnlineGPS.Value = 1;
                spGPS.Dispose();
            }
            //lblGPS1Comm.Text = "---";
            Settings.IO.setPort_wasGPSConnected = false;
        }

        //called by the GPS delegate every time a chunk is rec'd
        private void ReceiveGPSPort(string sentence)
        {
            try
            {
                traffic.cntrGPSOut += sentence.Length;

                pn.rawBuffer += sentence;
                pn.ParseNMEA(ref pn.rawBuffer);

                if (pn.isNMEAToSend)
                {
                    pn.isNMEAToSend = false;

                    if (!isGPSPositionInitialized) pn.SetLocalMetersPerDegree(pn.latitude, pn.longitude);

                    pn.ConvertWGS84ToLocal(pn.latitude, pn.longitude, out pn.fix.northing, out pn.fix.easting);

                    if (pn.headingTrueDual != float.MaxValue)
                    {
                        pn.headingTrueDual += Settings.Vehicle.setGPS_dualHeadingOffset;
                        if (pn.headingTrueDual >= 360) pn.headingTrueDual -= 360;
                        else if (pn.headingTrueDual < 0) pn.headingTrueDual += 360;
                    }

                    if (pn.imuHeading != ushort.MaxValue)
                    {
                        ahrs.imuHeading = pn.imuHeading;
                        ahrs.imuHeading *= 0.1;
                    }

                    if (pn.imuRoll != short.MaxValue)
                    {
                        double rollK = pn.imuRoll;
                        if (Settings.Vehicle.setIMU_invertRoll) rollK *= -0.1;
                        else rollK *= 0.1;
                        rollK -= Settings.Vehicle.setIMU_rollZero;
                        ahrs.imuRoll = ahrs.imuRoll * Settings.Vehicle.setIMU_rollFilter + rollK * (1 - Settings.Vehicle.setIMU_rollFilter);
                    }

                    if (pn.imuPitch != short.MaxValue)
                    {
                        ahrs.imuPitch = pn.imuPitch;
                    }

                    if (pn.imuYawRate != short.MaxValue)
                    {
                        ahrs.imuYawRate = pn.imuYawRate;
                    }

                    sentenceCounter = 0;
                    UpdateFixPosition();
                }
            }
            catch { }
        }

        //serial port receive in its own thread
        private void sp_DataReceivedGPS(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (spGPS.IsOpen)
            {
                try
                {
                    string sentence = spGPS.ReadExisting();
                    BeginInvoke((MethodInvoker)(() => ReceiveGPSPort(sentence)));
                }
                catch (Exception)
                {
                }
            }
        }

        #endregion SerialPortGPS

        #region GPS2 SerialPort //--------------------------------------------------------

        //called by the GPS2 delegate every time a chunk is rec'd
        private void ReceiveGPS2Port(string sentence)
        {
            //dead end
            //traffic.cntrGPS2Out += sentence.Length;
            recvGPS2Sentence = sentence;
        }
        public void SendGPS2Port(byte[] data)
        {
            try
            {
                if (spGPS2.IsOpen)
                {
                    spGPS2.Write(data, 0, data.Length);
                }
            }
            catch (Exception)
            {
            }

        }
        public void OpenGPS2Port()
        {
            //close it first
            CloseGPS2Port();

            //if (spGPS2.IsOpen)
            //{
            //    //simulatorOnToolStripMenuItem.Checked = false;
            //    //panelSim.Visible = false;
            //    //timerSim.Enabled = false;

            //    //Settings.IO.setMenu_isSimulatorOn = simulatorOnToolStripMenuItem.Checked;
            //    //
            //}

            if (!spGPS2.IsOpen)
            {
                spGPS2.PortName = Settings.IO.setPort_portNameGPS2;
                spGPS2.BaudRate = Settings.IO.setPort_baudRateGPS2;
                spGPS2.DataReceived += sp_DataReceivedGPS2;
                spGPS2.WriteTimeout = 1000;
            }

            try { spGPS2.Open(); }
            catch (Exception ex)
            {
                Log.EventWriter("Catch - > Serial GPS Open Fail: " + ex.ToString());
            }

            if (spGPS2.IsOpen)
            {
                //discard any stuff in the buffers
                spGPS2.DiscardOutBuffer();
                spGPS2.DiscardInBuffer();
            }
        }
        public void CloseGPS2Port()
        {
            //if (sp.IsOpen)
            {
                spGPS2.DataReceived -= sp_DataReceivedGPS2;
                try { spGPS2.Close(); }
                catch (Exception e)
                {
                    Log.EventWriter("Closing GPS2 Port" + e.ToString());
                    MessageBox.Show(e.Message, "Connection already terminated?");
                }

                //update port status labels
                //stripPortGPS2.Text = " * * " + baudRateGPS2.ToString();
                //stripPortGPS2.ForeColor = Color.ForestGreen;
                //stripOnlineGPS2.Value = 1;
                spGPS2.Dispose();
            }
        }

        //serial port receive in its own thread
        private void sp_DataReceivedGPS2(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (spGPS2.IsOpen)
            {
                try
                {
                    string sentence = spGPS2.ReadLine();
                    BeginInvoke((MethodInvoker)(() => ReceiveGPS2Port(sentence)));
                }
                catch (Exception)
                {
                }
            }
        }
        #endregion //--------------------------------------------------------

        #region RTCM Port //--------------------------------------------------

        public void OpenRtcmPort()
        {
            if (spRtcm.IsOpen)
            {
                //close it first
                CloseRtcmPort();
            }

            if (!spRtcm.IsOpen)
            {
                spRtcm.PortName = Settings.IO.setPort_portNameRtcm;
                spRtcm.BaudRate = Settings.IO.setPort_baudRateRtcm;
                spRtcm.WriteTimeout = 1000;
            }

            try { spRtcm.Open(); }
            catch (Exception ex)
            {
                Log.EventWriter("Catch - > Serial RTCM Open Fail: " + ex.ToString());
            }

            if (spRtcm.IsOpen)
            {
                //discard any stuff in the buffers
                spRtcm.DiscardOutBuffer();
                spRtcm.DiscardInBuffer();

                Settings.IO.setPort_wasRtcmConnected = true;
            }
        }

        public void CloseRtcmPort()
        {
            {
                try { spRtcm.Close(); }
                catch (Exception e)
                {
                    Log.EventWriter("Closing RTCM Port" + e.ToString());
                    MessageBox.Show(e.Message, "Connection already terminated?");
                }
            }

            Settings.IO.setPort_wasRtcmConnected = false;
        }

        #endregion

        #region GPSOut Port //-------------------------------------------------

        public void OpenGPSOutPort()
        {

            if (spGPSOut.IsOpen)
            {
                //close it first
                CloseGPSOutPort();
            }

            if (!spGPSOut.IsOpen)
            {
                spGPSOut.PortName = Settings.IO.setPort_portNameGPSOut;
                spGPSOut.BaudRate = Settings.IO.setPort_baudRateGPSOut;
                spGPSOut.WriteTimeout = 100;
            }

            try { spGPSOut.Open(); }
            catch (Exception ex)
            {
                Log.EventWriter("Catch - > Serial GPSOut Open Fail: " + ex.ToString());
            }

            if (spGPSOut.IsOpen)
            {
                //discard any stuff in the buffers
                spGPSOut.DiscardOutBuffer();
                spGPSOut.DiscardInBuffer();

                Settings.IO.setPort_wasGPSOutConnected = true;

                //lblGPSOut1Comm.Text = Settings.IO.setPort_portNameGPSOut;
            }
        }
        public void CloseGPSOutPort()
        {
            //if (sp.IsOpen)
            {
                try { spGPSOut.Close(); }
                catch (Exception e)
                {
                    Log.EventWriter("Closing GPSOut Port" + e.ToString());
                    MessageBox.Show(e.Message, "Connection already terminated?");
                }

                spGPSOut.Dispose();
            }

            //lblGPSOut1Comm.Text = "---";
            Settings.IO.setPort_wasGPSOutConnected = false;
        }

        #endregion
    }
}
