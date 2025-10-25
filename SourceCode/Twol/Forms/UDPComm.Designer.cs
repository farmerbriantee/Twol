using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.Diagnostics;
using System.Xml.Linq;
using System.Buffers;

using System.Text;
using Twol.Classes;

namespace Twol
{
    public class CTraffic
    {
        public int cntrGPSIn = 0;
        public int cntrGPSInBytes = 0;
        public int cntrGPSOut = 0;
        public int cntrGPSOutTool = 0;
        public int cntrGPS_OutSerial = 0;

        public uint helloFromMachine = 99, helloFromAutoSteer = 99, helloFromIMU = 99;
    }

    public class CScanReply
    {
        public string steerIP = "";
        public string machineIP = "";
        public string GPS_IP = "";
        public string IMU_IP = "";
        public string subnetStr = "";

        public byte[] subnet = { 0, 0, 0 };

        public bool isNewSteer, isNewMachine, isNewGPS, isNewIMU, isNewGPSTool;

        public bool isNewData = false;
    }

    public partial class FormGPS
    {
        private readonly Stopwatch swIOFrame = new Stopwatch();
        public static double gps_IO_Hz = 10;
        public double now_IO_Hz = 0;

        // UDP Socket
        public Socket UDPSocket, UDPSocketTool;
        private EndPoint endPointUDP = new IPEndPoint(IPAddress.Any, 0);
        private EndPoint endPointUDPTool = new IPEndPoint(IPAddress.Any, 0);

        public bool isUDPNetworkConnected, isUDPNetworkConnectedTool, isUDPMonitorOn;

        public bool isGPSToolActive = false;

        public IPEndPoint epModule = new IPEndPoint(IPAddress.Parse(
            Settings.IO.etIP_SubnetOne.ToString() + "." +
            Settings.IO.etIP_SubnetTwo.ToString() + "." +
            Settings.IO.etIP_SubnetThree.ToString() + ".255"), 8888);

        public IPEndPoint epModuleTool = new IPEndPoint(IPAddress.Parse(
            Settings.IO.etIP_SubnetOne.ToString() + "." +
            Settings.IO.etIP_SubnetTwo.ToString() + "." +
            Settings.IO.etIP_SubnetThree.ToString() + ".255"), 18888);

        public IPEndPoint epModuleSet = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 8888);
        public IPEndPoint epModuleSetTool = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 18888);
        private EndPoint epAgIO = new IPEndPoint(IPAddress.Parse("127.255.255.255"), 17777);

        private IPEndPoint epNtrip;

        public byte[] ipAutoSet = { 192, 168, 5 };

        // - App Sockets  -----------------------------------------------------
        private Socket loopBackSocket;

        //endpoints of modules
        private EndPoint endPointLoopBack = new IPEndPoint(IPAddress.Loopback, 0);

        // Data stream
        private byte[] loopBuffer = new byte[1024];


        //class for counting bytes
        public CTraffic traffic = new CTraffic();
        public CScanReply scanReply = new CScanReply();
        public CScanReply scanReplyTool = new CScanReply();

        //scan results placed here
        public string scanReturn = "Scanning...";

        // Data stream
        private byte[] buffer = new byte[1024];
        private byte[] bufferTool = new byte[1024];

        //used to send communication check pgn= C8 or 200
        private byte[] helloFromTwol = { 0x80, 0x81, 0x7F, 200, 3, 56, 0, 0, 0x47 };
        public StringBuilder logUDPSentence = new StringBuilder();
        public bool isGPSLogOn;

        public void DisableSim()
        {
            isGPSPositionInitialized = false;
            isFirstHeadingSet = false;
            startCounter = 0;
            panelSim.Visible = false;
            timerSim.Enabled = false;
            simulatorOnToolStripMenuItem.Checked = false;
            Settings.User.isSimulatorOn = simulatorOnToolStripMenuItem.Checked;

            return;
        }

        public void StartLoopbackServer()
        {
            try
            {
                // Initialise the socket
                loopBackSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                loopBackSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                loopBackSocket.Bind(new IPEndPoint(IPAddress.Loopback, 15555));
                loopBackSocket.BeginReceiveFrom(loopBuffer, 0, loopBuffer.Length, SocketFlags.None,
                    ref endPointLoopBack, new AsyncCallback(ReceiveAppData), null);
                Log.EventWriter("UDP Loopback network started: " + IPAddress.Loopback.ToString() + ":" + "15555");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.EventWriter("Catch -> Load UDP Loopback Error: " + ex.ToString());
            }
        }


        //initialize loopback and udp network
        public void LoadUDPNetwork()
        {
            helloFromTwol[5] = 56;

            lblIP.Text = "";
            try //udp network
            {
                foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
                {
                    if (IPA.AddressFamily == AddressFamily.InterNetwork)
                    {
                        string data = IPA.ToString();
                        lblIP.Text += IPA.ToString().Trim() + "\r\n";
                    }
                }

                // Initialise the socket
                UDPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                UDPSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                UDPSocket.Bind(new IPEndPoint(IPAddress.Any, 9999));
                UDPSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref endPointUDP,
                    new AsyncCallback(ReceiveDataUDPAsync), null);

                isUDPNetworkConnected = true;

                // Initialise the Tool socket
                UDPSocketTool = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                UDPSocketTool.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                UDPSocketTool.Bind(new IPEndPoint(IPAddress.Any, 19999));
                UDPSocketTool.BeginReceiveFrom(bufferTool, 0, bufferTool.Length, SocketFlags.None, ref endPointUDPTool,
                    new AsyncCallback(ReceiveDataUDPAsyncTool), null);

                isUDPNetworkConnectedTool = true;

                if (isUDPNetworkConnected)
                {
                    Log.EventWriter("UDP Network is connected: " + epModule.ToString());
                }
                else
                {
                    Log.EventWriter("UDP Network Failed to Connect");
                }

                if (isUDPNetworkConnectedTool)
                {
                    Log.EventWriter("UDP Tool Network is connected: " + epModuleTool.ToString());
                }
                else
                {
                    Log.EventWriter("UDP Tool Network Failed to Connect");
                }

                btnUDP.BackColor = Color.LimeGreen;
            }
            catch (Exception e)
            {
                Log.EventWriter("Catch -> Load UDP Server" + e);
                MessageBox.Show(e.Message, "Serious Network Connection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnUDP.BackColor = Color.Red;
                lblIP.Text = "Error";
            }
        }

        #region Send UDP

        public void SendUDPMessage(byte[] byteData, IPEndPoint endPoint)
        {
            // Validate network and data
            if (!isUDPNetworkConnected || byteData == null || byteData.Length == 0 || endPoint == null)
                return;

            try
            {
                // Cache endpoint string for logging (avoid indexing into byteData before checking length)
                string epStr = endPoint.ToString();

                // Begin asynchronous send
                UDPSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None,
                   endPoint, new AsyncCallback(SendDataUDPAsync), null);

                // Monitoring/logging - safe index check
                if (isUDPMonitorOn)
                {
                    string code = byteData.Length > 3 ? byteData[3].ToString() : "N/A";
                    logUDPSentence.Append(DateTime.Now.ToString("ss.fff\t") + epStr + "\t" + " > " + code + "\r\n");
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions to help diagnose network issues
                try { Log.EventWriter("SendUDPMessage error: " + ex.ToString()); } catch { }
            }
        }

        private void SendDataUDPAsync(IAsyncResult asyncResult)
        {
            try
            {
                UDPSocket.EndSend(asyncResult);
            }
            catch (ObjectDisposedException)
            {
                // Socket disposed while sending - ignore
            }
            catch (SocketException sex)
            {
                try { Log.EventWriter("SendDataUDPAsync SocketException: " + sex.ToString()); } catch { }
            }
            catch (Exception ex)
            {
                try { Log.EventWriter("SendDataUDPAsync error: " + ex.ToString()); } catch { }
            }
        }

        #endregion

        #region Recv_UDP
        private void ReceiveDataUDPAsync(IAsyncResult asyncResult)
        {
            try
            {
                // Receive all data
                int msgLen = UDPSocket.EndReceiveFrom(asyncResult, ref endPointUDP);
                if (msgLen <= 0)
                {
                    UDPSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref endPointUDP,
                        new AsyncCallback(ReceiveDataUDPAsync), null);
                    return;
                }

                // Rent a buffer sized to the message to avoid allocating every packet
                byte[] rented = ArrayPool<byte>.Shared.Rent(msgLen);
                Buffer.BlockCopy(buffer, 0, rented, 0, msgLen);

                // Listen for more connections again...
                UDPSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref endPointUDP,
                    new AsyncCallback(ReceiveDataUDPAsync), null);

                // Marshal to UI thread. Ensure rented buffer is returned after processing.
                BeginInvoke((MethodInvoker)(() =>
                {
                    try
                    {
                        ReceiveFromUDP(rented, msgLen);
                    }
                    finally
                    {
                        ArrayPool<byte>.Shared.Return(rented);
                    }
                }));
            }
            catch
            {
            }
        }

        private void ReceiveFromUDP(byte[] data, int msgLen)
        {
            try
            {
                if (msgLen < 2) return;

                if (data[0] == 0x80 && data[1] == 0x81)
                {
                    int length = msgLen;

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

                        case 212:
                            {
                                if (data[5] == 1)
                                {
                                    ahrs.imuHeading = 99999;
                                    ahrs.imuRoll = 88888;
                                    ahrs.angVel = 0;
                                }
                                break;
                            }

                        case 224:
                            {
                                Settings.Tool.setNozz.volumeApplied = (Int16)((data[6] << 8) + data[5]) * 0.1;
                                nozz.volumePerMinuteActual = (Int16)((data[8] << 8) + data[7]);
                                nozz.pressureActual = data[9];
                                nozz.isFlowingFlag = data[10] != 0;
                                nozz.pwmDriveActual = data[11];
                                if (data[12] == 0) nozz.pwmDriveActual *= -1;
                                nozz.frequency = (Int16)((data[14] << 8) + data[13]);
                                break;
                            }

                        case 221:
                            {
                                if (length < 9) break;
                                if (isHardwareMessages)
                                {
                                    int textLen = Math.Max(0, data[4] - 2);
                                    if (7 + textLen <= length)
                                        lblHardwareMessage.Text = Encoding.UTF8.GetString(data, 7, textLen);
                                    else
                                        lblHardwareMessage.Text = Encoding.UTF8.GetString(data, 7, Math.Max(0, length - 9));

                                    lblHardwareMessage.Visible = true;
                                    hardwareLineCounter = data[5] * 10;
                                    Log.EventWriter(lblHardwareMessage.Text);

                                    if (data[6] == 0)
                                    {
                                        lblHardwareMessage.BackColor = Color.Salmon;
                                        lblHardwareMessage.ForeColor = Color.Black;
                                    }
                                    else
                                    {
                                        lblHardwareMessage.BackColor = Color.Bisque;
                                        lblHardwareMessage.ForeColor = Color.Black;
                                    }
                                }
                                else
                                {
                                    lblHardwareMessage.Visible = false;
                                    hardwareLineCounter = 0;
                                }
                                break;
                            }

                        case 234:
                            {
                                if (length != 14) break;
                                Buffer.BlockCopy(data, 5, mc.ss, 1, 8);
                                DoRemoteSwitches();
                                break;
                            }

                        case 126:
                            {
                                if (length == 11) traffic.helloFromAutoSteer = 0;
                                break;
                            }

                        case 123:
                            {
                                if (length == 11) traffic.helloFromMachine = 0;
                                break;
                            }

                        case 121:
                            {
                                if (length == 11) traffic.helloFromIMU = 0;
                                break;
                            }

                        case 203:
                            {
                                if (length == 13)
                                {
                                    if (data[2] == 126)
                                    {
                                        scanReply.steerIP = $"{data[5]}.{data[6]}.{data[7]}.{data[8]}";
                                        scanReply.subnet[0] = data[9];
                                        scanReply.subnet[1] = data[10];
                                        scanReply.subnet[2] = data[11];
                                        scanReply.subnetStr = $"{data[9]}.{data[10]}.{data[11]}";
                                        scanReply.isNewData = true;
                                        scanReply.isNewSteer = true;
                                    }
                                    else if (data[2] == 123)
                                    {
                                        scanReply.machineIP = $"{data[5]}.{data[6]}.{data[7]}.{data[8]}";
                                        scanReply.subnet[0] = data[9];
                                        scanReply.subnet[1] = data[10];
                                        scanReply.subnet[2] = data[11];
                                        scanReply.subnetStr = $"{data[9]}.{data[10]}.{data[11]}";
                                        scanReply.isNewData = true;
                                        scanReply.isNewMachine = true;
                                    }
                                    else if (data[2] == 121)
                                    {
                                        scanReply.IMU_IP = $"{data[5]}.{data[6]}.{data[7]}.{data[8]}";
                                        scanReply.subnet[0] = data[9];
                                        scanReply.subnet[1] = data[10];
                                        scanReply.subnet[2] = data[11];
                                        scanReply.subnetStr = $"{data[9]}.{data[10]}.{data[11]}";
                                        scanReply.isNewData = true;
                                        scanReply.isNewIMU = true;
                                    }
                                    else if (data[2] == 120)
                                    {
                                        scanReply.GPS_IP = $"{data[5]}.{data[6]}.{data[7]}.{data[8]}";
                                        scanReply.subnet[0] = data[9];
                                        scanReply.subnet[1] = data[10];
                                        scanReply.subnet[2] = data[11];
                                        scanReply.subnetStr = $"{data[9]}.{data[10]}.{data[11]}";
                                        scanReply.isNewData = true;
                                        scanReply.isNewGPS = true;
                                    }
                                }
                                break;
                            }
                    }

                    if (isUDPMonitorOn)
                    {
                        logUDPSentence.Append(DateTime.Now.ToString("ss.fff\t") + endPointUDP.ToString() + "\t" + " < " + data[3].ToString() + "\r\n");
                    }
                }
                else if (data[0] == 36 && (data[1] == 71 || data[1] == 80 || data[1] == 75))
                {
                    double timeSliceOfLastFix = (double)(swIOFrame.ElapsedTicks) / Stopwatch.Frequency;
                    swIOFrame.Restart();

                    now_IO_Hz = 1 / timeSliceOfLastFix;
                    if (now_IO_Hz > 35) now_IO_Hz = 35;
                    if (now_IO_Hz < 5) now_IO_Hz = 5;

                    gps_IO_Hz = 0.98 * gps_IO_Hz + 0.02 * now_IO_Hz;
                    traffic.cntrGPSOut += msgLen;

                    pn.rawBuffer += Encoding.ASCII.GetString(data, 0, msgLen);
                    pn.ParseNMEA(ref pn.rawBuffer);

                    //if (isUDPMonitorOn && isGPSLogOn)
                    //{
                    //    logUDPSentence.Append(DateTime.Now.ToString("ss.fff\t") + System.Text.Encoding.ASCII.GetString(data));
                    //}

                    if (pn.isNMEAToSend)
                    {
                        pnTool.isNMEAToSend = false;

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
            }
            catch
            {
            }
        }

        #endregion

        #region Send_Tool_UDP

        public void SendUDPMessageTool(byte[] byteData, IPEndPoint endPoint)
        {
            if (isUDPNetworkConnectedTool)
            {
                //if (isUDPMonitorOn)
                //{
                //    logUDPSentence.Append(DateTime.Now.ToString("ss.fff\t") + endPoint.ToString() + "\t" + " > " + byteData[3].ToString() + "\r\n");
                //}

                try
                {
                    // Send packet to the zero
                    if (byteData.Length != 0)
                    {
                        UDPSocketTool.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None,
                           endPoint, new AsyncCallback(SendDataUDPAsyncTool), null);
                    }
                }
                catch (Exception)
                {
                    //WriteErrorLog("Sending UDP Message" + e.ToString());
                    //MessageBox.Show("Send Error: " + e.Message, "UDP Client", MessageBoxButtons.OK,
                    //MessageBoxIcon.Error);
                }
            }
        }

        private void SendDataUDPAsyncTool(IAsyncResult asyncResult)
        {
            try
            {
                UDPSocketTool.EndSend(asyncResult);
            }
            catch
            {
            }
        }

        #endregion

        #region Recv_UDP_Tool

        private void ReceiveDataUDPAsyncTool(IAsyncResult asyncResult)
        {
            try
            {
                int msgLen = UDPSocketTool.EndReceiveFrom(asyncResult, ref endPointUDPTool);
                if (msgLen <= 0)
                {
                    UDPSocketTool.BeginReceiveFrom(bufferTool, 0, bufferTool.Length, SocketFlags.None, ref endPointUDPTool,
                        new AsyncCallback(ReceiveDataUDPAsyncTool), null);
                    return;
                }

                byte[] rented = ArrayPool<byte>.Shared.Rent(msgLen);
                Buffer.BlockCopy(bufferTool, 0, rented, 0, msgLen);

                UDPSocketTool.BeginReceiveFrom(bufferTool, 0, bufferTool.Length, SocketFlags.None, ref endPointUDPTool,
                    new AsyncCallback(ReceiveDataUDPAsyncTool), null);

                BeginInvoke((MethodInvoker)(() =>
                {
                    try
                    {
                        ReceiveFromUDPTool(rented, msgLen);
                    }
                    finally
                    {
                        ArrayPool<byte>.Shared.Return(rented);
                    }
                }));
            }
            catch
            {
            }
        }

        private void ReceiveFromUDPTool(byte[] data, int msgLen)
        {
            try
            {
                if (msgLen < 2) return;

                if (data[0] == 0x80 && data[1] == 0x81)
                {
                    int length = msgLen;

                    switch (data[3])
                    {
                        case 230:
                            {
                                if (length != 14) break;
                                mc.actualToolAngleChart = (Int16)((data[6] << 8) + data[5]);
                                mc.actualToolAngleDegrees = (double)mc.actualToolAngleChart * 0.01;
                                mc.pwmToolDisplay = data[12];
                                break;
                            }

                        case 226:
                            {
                                if (length == 11) traffic.helloFromAutoSteer = 0;
                                break;
                            }

                        case 203:
                            {
                                if (length == 13)
                                {
                                    if (data[2] == 220)
                                    {
                                        scanReplyTool.GPS_IP = $"{data[5]}.{data[6]}.{data[7]}.{data[8]}";
                                        scanReplyTool.subnet[0] = data[9];
                                        scanReplyTool.subnet[1] = data[10];
                                        scanReplyTool.subnet[2] = data[11];
                                        scanReplyTool.subnetStr = $"{data[9]}.{data[10]}.{data[11]}";
                                        scanReplyTool.isNewData = true;
                                        scanReplyTool.isNewGPS = true;
                                    }
                                }
                                break;
                            }
                    }
                }
                else if (data[0] == 36 && (data[1] == 71 || data[1] == 80 || data[1] == 75))
                {
                    traffic.cntrGPSOutTool += msgLen;
                    pnTool.rawBuffer += Encoding.ASCII.GetString(data, 0, msgLen);
                    pnTool.ParseNMEA(ref pnTool.rawBuffer);

                    if (pnTool.isNMEAToSend)
                    {
                        pnTool.isNMEAToSend = false;
                        pnTool.ConvertWGS84ToLocal(pnTool.latitude, pnTool.longitude, out pnTool.fix.northing, out pnTool.fix.easting);

                        if (pnTool.headingTrueDual != float.MaxValue)
                        {
                            pnTool.headingTrueDual += Settings.Vehicle.setGPS_dualHeadingOffset;
                            if (pnTool.headingTrueDual >= 360) pnTool.headingTrueDual -= 360;
                            else if (pnTool.headingTrueDual < 0) pnTool.headingTrueDual += 360;
                        }

                        if (pnTool.imuHeading != ushort.MaxValue)
                        {
                            ahrsTool.imuHeading = pnTool.imuHeading;
                            ahrsTool.imuHeading *= 0.1;
                        }

                        if (pnTool.imuRoll != short.MaxValue)
                        {
                            double rollK = pnTool.imuRoll;
                            if (Settings.Vehicle.setIMU_invertRoll) rollK *= -0.1;
                            else rollK *= 0.1;
                            rollK -= Settings.Vehicle.setIMU_rollZero;
                            ahrsTool.imuRoll = ahrsTool.imuRoll * Settings.Vehicle.setIMU_rollFilter + rollK * (1 - Settings.Vehicle.setIMU_rollFilter);
                        }

                        if (Settings.Tool.setToolSteer.antennaOffset != 0)
                        {
                            pnTool.fix.easting += Math.Cos(fixHeading) * Settings.Tool.setToolSteer.antennaOffset;
                            pnTool.fix.northing -= Math.Sin(fixHeading) * Settings.Tool.setToolSteer.antennaOffset;
                        }

                        if (ahrsTool.imuRoll != 0 && Settings.Tool.setToolSteer.antennaHeight != 0)
                        {
                            rollCorrectionDistance = Math.Sin(glm.toRadians((ahrsTool.imuRoll))) * -Settings.Tool.setToolSteer.antennaHeight;
                            pnTool.fix.easting = (Math.Cos(-fixHeading) * rollCorrectionDistance) + pnTool.fix.easting;
                            pnTool.fix.northing = (Math.Sin(-fixHeading) * rollCorrectionDistance) + pnTool.fix.northing;
                        }

                        if (pnTool.imuPitch != short.MaxValue)
                        {
                            ahrsTool.imuPitch = pnTool.imuPitch;
                        }

                        if (pnTool.imuYawRate != short.MaxValue)
                        {
                            ahrsTool.imuYawRate = pnTool.imuYawRate;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        #endregion

        #region Loopback to plugins
        private void ReceiveFromAgIO(byte[] data)
        {
            try
            {
                if (data.Length > 4 && data[0] == 0x80 && data[1] == 0x81)
                {
                    int Length = Math.Max((data[4]) + 5, 5);
                    if (data.Length > Length)
                    {
                        byte CK_A = 0;
                        for (int j = 2; j < Length; j++)
                        {
                            CK_A += data[j];
                        }

                        if (data[Length] != (byte)CK_A)
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }

                    switch (data[3])
                    {
                        #region Remote Switches
                        case 234://MTZ8302 Feb 2020
                            {
                                //Steer angle actual
                                if (data.Length != 14)
                                    break;

                                Buffer.BlockCopy(data, 5, mc.ss, 1, 8);

                                DoRemoteSwitches();

                                break;
                            }
                            #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                Log.EventWriter($"Catch ReceiveFromAgIO error: {ex.Message}");
            }
        }

        private void ReceiveAppData(IAsyncResult asyncResult)
        {
            try
            {
                // Receive all data
                int msgLen = loopBackSocket.EndReceiveFrom(asyncResult, ref endPointLoopBack);

                byte[] localMsg = new byte[msgLen];
                Array.Copy(loopBuffer, localMsg, msgLen);

                // Listen for more connections again...
                loopBackSocket.BeginReceiveFrom(loopBuffer, 0, loopBuffer.Length, SocketFlags.None,
                    ref endPointLoopBack, new AsyncCallback(ReceiveAppData), null);

                BeginInvoke((MethodInvoker)(() => ReceiveFromAgIO(localMsg)));
            }
            catch (Exception)
            {
                // MessageBox.Show("ReceiveData Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SendPgnToLoop(byte[] byteData)
        {
            if (loopBackSocket != null && byteData.Length > 2)
            {
                try
                {
                    int crc = 0;
                    for (int i = 2; i + 1 < byteData.Length; i++)
                    {
                        crc += byteData[i];
                    }
                    byteData[byteData.Length - 1] = (byte)crc;

                    loopBackSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None,
                        epAgIO, new AsyncCallback(SendAsyncLoopData), null);
                }
                catch (Exception)
                {
                    //Log.EventWriter("Sending UDP Message" + e.ToString());
                    //MessageBox.Show("Send Error: " + e.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SendAsyncLoopData(IAsyncResult asyncResult)
        {
            try
            {
                loopBackSocket.EndSend(asyncResult);
            }
            catch (Exception)
            {
                //MessageBox.Show("SendData Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


        //for moving and sizing borderless window
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 7;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        #region keystrokes
        //keystrokes for easy and quick startup
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((char)keyData == hotkeys[0]) //autosteer button on off
            {
                SetAutoSteerButton(!isBtnAutoSteerOn, "Hotkey Triggered");
                return true;    // indicate that you handled this keystroke
            }

            if ((char)keyData == hotkeys[1]) //open the steer chart
            {
                btnCycleLines.PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if ((char)keyData == hotkeys[2])
            {
                FileSaveEverythingBeforeClosingField();
                return true;    // indicate that you handled this keystroke
            }

            if ((char)keyData == hotkeys[3]) // Flag click
            {
                btnFlag.PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if ((char)keyData == hotkeys[4]) //auto section on off
            {
                SetWorkState(workState == btnStates.On ? btnStates.Off : btnStates.On);
                return true;    // indicate that you handled this keystroke
            }

            if ((char)keyData == hotkeys[5]) //auto section on off
            {
                SetWorkState(workState == btnStates.Auto ? btnStates.Off : btnStates.Auto);
                return true;    // indicate that you handled this keystroke
            }

            if ((char)keyData == hotkeys[6]) // Snap/Prioritu click
            {
                trk.SnapToPivot(trk.currTrk);
                return true;    // indicate that you handled this keystroke
            }

            if ((char)keyData == hotkeys[7])
            {
                trk.NudgeTrack(trk.currTrk, -Settings.Vehicle.setAS_snapDistance);
                return true;
            }

            if ((char)keyData == hotkeys[8])
            {
                trk.NudgeTrack(trk.currTrk, Settings.Vehicle.setAS_snapDistance);
                return true;
            }

            if ((char)keyData == (hotkeys[9])) //open the vehicle Settings
            {
                toolStripConfig.PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if ((char)keyData == (hotkeys[10])) // Wizard
            {
            }

            if ((char)keyData == (hotkeys[11])) //section or zone button
            {
                if (controlButtons.Count > 0)
                    controlButtons[0].PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if ((char)keyData == (hotkeys[12])) //section or zone button
            {
                if (controlButtons.Count > 1)
                    controlButtons[1].PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if ((char)keyData == (hotkeys[13])) //section or zone button
            {
                if (controlButtons.Count > 2)
                    controlButtons[2].PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if ((char)keyData == (hotkeys[14])) //section or zone button
            {
                if (controlButtons.Count > 3)
                    controlButtons[3].PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if ((char)keyData == (hotkeys[15])) //section or zone button
            {
                if (controlButtons.Count > 4)
                    controlButtons[4].PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if ((char)keyData == (hotkeys[16])) //section or zone button
            {
                if (controlButtons.Count > 5)
                    controlButtons[5].PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if ((char)keyData == (hotkeys[17])) //section or zone button
            {
                if (controlButtons.Count > 6)
                    controlButtons[6].PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if ((char)keyData == (hotkeys[18])) //section or zone button
            {
                if (controlButtons.Count > 7)
                    controlButtons[7].PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            //////////////////////////////////////////////

            if (keyData == (Keys.NumPad1)) //auto section on off
            {
                SetWorkState(workState == btnStates.Auto ? btnStates.Off : btnStates.Auto);
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == (Keys.NumPad0)) //auto section on off
            {
                SetWorkState(workState == btnStates.On ? btnStates.Off : btnStates.On);
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == (Keys.F11)) // Full Screen click
            {
                btnMaximizeMainForm.PerformClick();
                return true;    // indicate that you handled this keystroke
            }


            //reset Sim
            if (keyData == Keys.R)
            {
                btnResetSim.PerformClick();
                return true;
            }

            //UTurn
            if (keyData == Keys.U)
            {
                sim.Reverse();
            }

            //speed up
            if (keyData == Keys.Up)
            {
                if (sim.stepDistance < 0.4 && sim.stepDistance > -0.36) sim.stepDistance += 0.01;
                else 
                    sim.stepDistance += 0.04;
                if (sim.stepDistance > 4) sim.stepDistance = 4;
                return true;
            }

            //slow down
            if (keyData == Keys.Down)
            {
                if (sim.stepDistance < 0.2 && sim.stepDistance > -0.04) sim.stepDistance -= 0.01;
                else sim.stepDistance -= 0.04;
                if (sim.stepDistance < -0.35) sim.stepDistance = -0.35;
                return true;
            }

            //Stop
            if (keyData == Keys.OemPeriod)
            {
                sim.stepDistance = 0;
                return true;
            }

            //turn right
            if (keyData == Keys.Right)
            {
                steerAngleScrollBar += 1.0;
                return true;
            }

            //turn left
            if (keyData == Keys.Left)
            {
                steerAngleScrollBar -= 1.0;
                return true;
            }

            //zero steering
            if (keyData == Keys.OemQuestion)
            {
                steerAngleScrollBar = 0.0;
                return true;
            }

            if (keyData == Keys.OemOpenBrackets)
            {
                sim.isAccelBack = true;
            }

            if (keyData == Keys.OemCloseBrackets)
            {
                sim.isAccelForward = true;
            }

            if (keyData == Keys.OemQuotes)
            {
                sim.stepDistance = 0;
                return true;
            }

            if (keyData == (Keys.F6)) // Fast/Normal Sim
            {
                if (timerSim.Enabled)
                {
                    if (timerSim.Interval < 50)
                    {
                        timerSim.Interval = 94;
                        TimedMessageBox(2200, "Simulation Speed","Simulation speed set to 10Hz");
                    }
                    else
                    {
                        timerSim.Interval = 45;
                        TimedMessageBox(2200, "Simulation Speed", "Simulation speed set to 20Hz");
                    }
                }

                return true;    // indicate that you handled this keystroke
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}