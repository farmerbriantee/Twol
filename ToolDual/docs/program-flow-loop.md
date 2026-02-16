# ToolDual firmware program flow: loop

## Overview
`loop()` executes continuously and processes serial data, dual-antenna packets, UDP traffic, autosteer control, and LED/status timing. Most logic is conditional; some actions are gated by time checks or by data completeness.

## End-to-end cycle (single pass through `loop()`)

1. **Read NMEA from the main GPS (`SerialGPS`)**
   - If `SerialGPS.available()` is non-zero, one byte is read and fed into the NMEA parser.
   - `GGA_Handler`, `VTG_Handler`, and `HPR_Handler` may be invoked by the parser when complete sentences are recognized.
   - `GGA_Handler` sets `dualReadyGGA = true` and updates `gpsReadyTime`.

2. **Read RELPOSNED from the heading GPS (`SerialGPS2`)**
   - If `SerialGPS2.available()` is non-zero, one byte is read.
   - Bytes are accumulated into `ackPacket` once the 4-byte UBX header has been matched.
   - `relposnedByteCount` tracks progress and resets if the header sequence breaks.

3. **Send combined dual-antenna output (gated)**
   - If **both** `dualReadyGGA == true` **and** `dualReadyRelPos == true`, `BuildNmea()` is called and both flags are reset to `false`.
   - This means the output can lag until both the latest GGA and RELPOSNED-derived roll/heading are ready.

4. **Validate and decode RELPOSNED (gated by buffer size)**
   - When `relposnedByteCount > 71`, a full UBX packet is assumed to be in `ackPacket`.
   - `calcChecksum()` is executed; if it passes:
     - The red GPS LED is turned off.
     - `useDual = true`.
     - `relPosDecode()` runs to compute heading/roll.
   - `relposnedByteCount` is reset to `0` after processing.

5. **UDP receive (toolsteer data)**
   - `ReceiveUdp()` runs each loop.
   - If Ethernet is not running, it returns immediately.
   - When a UDP packet is present:
     - Tool steer data updates `toolXTE_Set`, `vehicleXTE`, `gpsSpeed`, and watchdog state.
     - Tool steer settings/config may be saved to EEPROM when those PGNs arrive.
     - A status packet (`PGN_230`) or hello response can be sent back.

6. **Autosteer loop (timed)**
   - `toolsteerLoop()` contains its own timing gate:
     - It runs its internal control loop only when `currentTime - steerLoopLastTime >= LOOP_TIME`.
     - With `LOOP_TIME = 25 ms`, the steering/control block runs at ~40 Hz.
   - Within the timed block:
     - Switches and steering sensors are read.
     - Steering position and angle are computed.
     - Watchdog logic can disable steering if data is stale.
     - PID and motor control only execute when steering is enabled.

7. **UDP NTRIP passthrough (gated by Ethernet and packet length)**
   - `udpNtrip()` is called every loop.
   - If `Ethernet_running` is `false`, it returns immediately.
   - When an NTRIP packet is present, it is read and forwarded to `SerialGPS`.

8. **RTK radio passthrough**
   - If `SerialRTK.available()` is non-zero, one byte is read and forwarded to `SerialGPS`.

9. **USB (Twol) passthrough**
   - If `SerialTwol.available()` is non-zero, one byte is read and forwarded to `SerialGPS`.

10. **Ethernet link LED status**
    - If `Ethernet.linkStatus() == LinkOFF`, sets the power LED on and ethernet LED off.
    - If `Ethernet.linkStatus() == LinkON`, sets the power LED off and ethernet LED on.

11. **GGA timeout (10 s watchdog)**
    - If `systick_millis_count - gpsReadyTime > 10000`, GPS LEDs are turned off and `useDual` is reset to `false`.

## Timing and gating summary
- **Dual-antenna output** requires **both** a recent GGA (`dualReadyGGA`) and a RELPOSNED-derived roll/heading (`dualReadyRelPos`).
- **RELPOSNED decoding** happens only once `relposnedByteCount > 71` (full packet collected).
- **Autosteer loop** runs at ~40 Hz due to the `LOOP_TIME = 25 ms` gate.
- **NTRIP forwarding** occurs only when Ethernet is running and a UDP packet is present.
- **GGA timeout** disables dual mode after 10 seconds without a new GGA.
