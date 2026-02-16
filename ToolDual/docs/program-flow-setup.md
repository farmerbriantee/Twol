# ToolDual firmware program flow: setup

## Overview
`setup()` performs a one-time initialization of hardware, serial ports, and networking before the main loop begins. The flow is linear and blocking only for the configured delays.

## Sequence
1. **Startup delay**
   - Waits `500 ms` to allow the USB serial monitor to attach.

2. **GPIO setup**
   - Configures LED pins as outputs: `GGAReceivedLED`, `Power_on_LED`, `Ethernet_Active_LED`, `GPSRED_LED`, `GPSGREEN_LED`, `AUTOSTEER_STANDBY_LED`, `AUTOSTEER_ACTIVE_LED`.

3. **NMEA parser setup**
   - Sets the parser error handler (`errorHandler`).
   - Registers handlers for NMEA sentences:
     - `G-GGA` -> `GGA_Handler`
     - `G-VTG` -> `VTG_Handler`
     - `G-HPR` -> `HPR_Handler`
 
4. **USB serial (Twol) initialization**
   - Starts `Serial` at `baudTwol` with a short `10 ms` delay before and after `begin()`.
   - Logs status messages to USB.

5. **GPS serial initialization**
   - Starts `SerialGPS` at `baudGPS`.
   - Attaches RX/TX ring buffers (`GPSrxbuffer`, `GPStxbuffer`).

6. **RTK radio serial initialization**
   - Starts `SerialRTK` at `baudRTK`.
   - Attaches RX buffer (`RTKrxbuffer`).

7. **Heading GPS serial initialization**
   - Starts `SerialGPS2` at `baudGPS`.
   - Attaches RX/TX ring buffers (`GPS2rxbuffer`, `GPS2txbuffer`).

8. **Autosteer initialization** (`ToolsteerSetup()`)
   - Configures PWM frequency for the motor driver outputs.
   - Initializes switch inputs and driver enable pins.
   - Initializes I2C and ADS1115 ADC.
   - Loads settings from EEPROM or writes defaults on first boot.
   - Initializes steering constants and driver configuration.
   - Sets standby/active LEDs accordingly.

9. **Ethernet initialization** (`EthernetStart()`)
   - Starts the Ethernet stack and checks for hardware/link.
   - Loads subnet and host IP from EEPROM (`networkAddress`).
   - Configures local IP and the broadcast destination.
   - Opens UDP sockets for:
     - GPS output (`Eth_udpPAOGI`)
     - NTRIP input (`Eth_udpNtrip`)
     - Toolsteer input/output (`Eth_udpToolSteer`)
   - Sets `Ethernet_running = true` when ready.

10. **Startup completes**
    - Logs final status and exits `setup()`. The firmware begins the main `loop()`.

## Timing notes
- Setup uses explicit delays (`500 ms`, then several `10 ms` pauses) to allow serial peripherals to initialize cleanly.
- There are no interrupts or timers used during setup; it is strictly sequential.
