using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Globalization;
using System.IO.Ports;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

// Declare the delegate prototype to send data back to the form
delegate void UpdateRTCM_Data(byte[] data);

namespace Twol
{
    public partial class FormGPS
    {
        //for the NTRIP CLient counting
        private int ntripCounter = 15;

        private Socket clientSocket;                      // Server connection
        private byte[] casterRecBuffer = new byte[2800];    // Recieved data buffer

        //Send GGA back timer - use threaded timer to avoid UI thread dependency
        private System.Threading.Timer tmr;

        private string GGASentence;

        public uint tripBytes = 0;
        private int NTRIP_Watchdog = 100;

        public bool isNTRIP_Connected = false;
        public bool isNTRIP_Starting = false;
        public bool isNTRIP_Connecting = false;
        public bool isNTRIP_Sending = false;
        public bool isRunGGAInterval = false;

        //set up connection to Caster
        private void DoNTRIPSecondRoutine()
        {
            //count up the ntrip clock only if everything is alive
            if (Settings.IO.setNTRIP_isOn || Settings.IO.setPass_isOn)
            {
                IncrementNTRIPWatchDog();
            }

            //Have we NTRIP connection
            if (Settings.IO.setNTRIP_isOn && !isNTRIP_Connected && !isNTRIP_Connecting)
            {
                if (!isNTRIP_Starting && ntripCounter > 20)
                {
                    // fire-and-forget async connect
                    _ = StartNTRIPAsync();
                }
            }

            if ( Settings.IO.setPass_isOn && !isNTRIP_Connected && !isNTRIP_Connecting)
            {
                if (!isNTRIP_Starting)
                {
                    // fire-and-forget async connect
                    _ = StartNTRIPAsync();
                }
            }

            if (isNTRIP_Connecting)
            {
                if (ntripCounter > 29)
                {
                    TimedMessageBox(1500, "Connection Problem", "Not Connecting To Caster");
                    ReconnectRequest();
                }
                if (clientSocket != null && clientSocket.Connected)
                {
                    SendAuthorization();
                }
            }
        }

        public void ConfigureNTRIP()
        {
            lblWatch.Text = "Wait GPS";
            //lblNTRIP_IP.Text = "";
            lblMount.Text = "";

            //start NTRIP if required
            if (Settings.IO.setPass_isOn)
            {
                // Immediatly connect radio
                ntripCounter = 20;
            }

            if (Settings.IO.setNTRIP_isOn || Settings.IO.setPass_isOn)
            {
                btnStartStopNtrip.Visible = true;
                btnStartStopNtrip.Visible = true;
                lblWatch.Visible = true;
                lblNTRIPBytes.Visible = true;
                lblToGPS.Visible = true;
                lblMount.Visible = true;
                //lblNTRIP_IP.Visible = true;
            }
            else
            {
                btnStartStopNtrip.Visible = false;
                btnStartStopNtrip.Visible = false;
                lblWatch.Visible = false;
                lblNTRIPBytes.Visible = false;
                lblToGPS.Visible = false;
                lblMount.Visible = false;
                //lblNTRIP_IP.Visible = false;
            }

            btnStartStopNtrip.Text = "Off";

            //update Caster IP from URL, just use the old one if can't find
            if (Settings.IO.setNTRIP_isOn)
            {
                //broadCasterIP = Settings.IO.setNTRIP_casterIP; //Select correct Address
                Settings.IO.setNTRIP_casterIP = null;
                string actualIP = Settings.IO.setNTRIP_casterURL.Trim();

                try
                {
                    IPAddress[] addresslist = Dns.GetHostAddresses(actualIP);
                    foreach (IPAddress address in addresslist)
                    {
                        if (address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            Settings.IO.setNTRIP_casterIP = address.ToString().Trim();

                            break;
                        }
                    }

                    if (Settings.IO.setNTRIP_casterIP == null) throw new NullReferenceException();
                }
                catch (Exception ex)
                {
                    Log.EventWriter(ex.ToString());
                    TimedMessageBox(1500, "URL Not Located, Network Down?", "Cannot Find: " + Settings.IO.setNTRIP_casterURL);
                    //if we had a timer already, kill it
                    tmr?.Dispose();

                    //use last known TODO
                    Settings.IO.setNTRIP_casterIP = Settings.IO.setNTRIP_casterIP; //Select correct Address

                    // Close the socket if it is still open
                    if (clientSocket != null && clientSocket.Connected)
                    {
                        clientSocket.Shutdown(SocketShutdown.Both);
                        System.Threading.Thread.Sleep(100);
                        clientSocket.Close();
                    }

                    //TimedMessageBox(2000, "NTRIP Not Connected", " Reconnect Request");
                    ntripCounter = 15;
                    isNTRIP_Connected = false;
                    isNTRIP_Starting = false;
                    isNTRIP_Connecting = false;
                    return;
                }
            }
        }

        public async Task StartNTRIPAsync()
        {
            if (Settings.IO.setNTRIP_isOn)
            {
                //if we had a timer already, kill it
                if (tmr != null)
                {
                    tmr.Dispose();
                    tmr = null;
                }

                //create new threaded timer at fast rate to start
                if (Settings.IO.setNTRIP_sendGGAInterval > 0)
                {
                    // dueTime = 5000ms to start fast, period = Timeout.Infinite until we set the regular interval
                    tmr = new System.Threading.Timer(NTRIPTimerCallback, null, 5000, Timeout.Infinite);
                }

                try
                {
                    // Close the socket if it is still open
                    if (clientSocket != null && clientSocket.Connected)
                    {
                        clientSocket.Shutdown(SocketShutdown.Both);
                        System.Threading.Thread.Sleep(100);
                        clientSocket.Close();
                    }

                    //NTRIP endpoint
                    epNtrip = new IPEndPoint(IPAddress.Parse(
                        Settings.IO.etIP_SubnetOne.ToString() + "." +
                        Settings.IO.etIP_SubnetTwo.ToString() + "." +
                        Settings.IO.etIP_SubnetThree.ToString() + ".255"), Settings.IO.setNTRIP_sendToUDPPort);

                    // Create the socket object
                    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    clientSocket.NoDelay = true;
                    clientSocket.Blocking = false;
                    clientSocket.BeginConnect(new IPEndPoint(IPAddress.Parse(Settings.IO.setNTRIP_casterIP), Settings.IO.setNTRIP_casterPort), new AsyncCallback(OnConnect), null);

                    Log.EventWriter("NTRIP - IP: " + Settings.IO.setNTRIP_casterIP.ToString() + ":" + Settings.IO.setNTRIP_casterPort.ToString()
                        + " To Port: " + Settings.IO.setNTRIP_sendToUDPPort.ToString() + " Mount: " + Settings.IO.setNTRIP_mount);
                }
                catch (Exception ex)
                {
                    ReconnectRequest();
                    Log.EventWriter("Catch - > NTRIP Reconnect Request: " + ex.ToString());
            
                    return;
                }

                isNTRIP_Connecting = true;
                //lblNTRIP_IP.Text = Settings.IO.setNTRIP_casterIP;
                lblMount.Text = Settings.IO.setNTRIP_mount;
            }
            else if (Settings.IO.setPass_isOn)
            {
                epNtrip = new IPEndPoint(IPAddress.Parse(
                    Settings.IO.etIP_SubnetOne.ToString() + "." +
                    Settings.IO.etIP_SubnetTwo.ToString() + "." +
                    Settings.IO.etIP_SubnetThree.ToString() + ".255"), Settings.IO.setNTRIP_sendToUDPPort);

                if (!string.IsNullOrEmpty(Settings.IO.setPort_portNameRadio))
                {
                    // Disconnect when already connected

                    isNTRIP_Connecting = false;
                    isNTRIP_Connected = true;
                    lblWatch.Text = "RTCM Serial";
                }
            }

            await Task.CompletedTask;
        }

        private void ReconnectRequest()
        {
            //TimedMessageBox(2000, "NTRIP Not Connected", " Reconnect Request");
            ntripCounter = 15;
            isNTRIP_Connected = false;
            isNTRIP_Starting = false;
            isNTRIP_Connecting = false;

            //if we had a timer already, kill it
            if (tmr != null)
            {
                tmr.Dispose();
                tmr = null;
            }
        }

        private void IncrementNTRIPWatchDog()
        {
            //increment once every second
            ntripCounter++;

            //Thinks is connected but not receiving anything
            if (NTRIP_Watchdog++ > 30 && isNTRIP_Connected) 
                ReconnectRequest();

            //Once all connected set the timer GGA to NTRIP Settings
            if (Settings.IO.setNTRIP_sendGGAInterval > 0 && ntripCounter == 40)
            {
                // set timer to repeat at configured interval
                try
                {
                    int period = Settings.IO.setNTRIP_sendGGAInterval * 1000;
                    tmr?.Change(period, period);
                }
                catch (Exception) { }
            }
        }

        private void SendAuthorization()
        {
            // Check we are connected
            if (clientSocket == null || !clientSocket.Connected)
            {
                //TimedMessageBox(2000, gStr.gsNTRIPNotConnected, " At the StartNTRIP() ");
                ReconnectRequest();
                return;
            }

            // Read the message from settings and send it
            try
            {
                if (!Settings.IO.setNTRIP_isTCP)
                {
                    //encode user and password
                    string auth = ToBase64(Settings.IO.setNTRIP_userName + ":" + Settings.IO.setNTRIP_userPassword);

                    //grab location sentence
                    BuildGGA();
                    GGASentence = sbGGA.ToString();

                    string htt;
                    if (Settings.IO.setNTRIP_isHTTP10) htt = "1.0";
                    else htt = "1.1";

                    //Build authorization string
                    string str = "GET /" + Settings.IO.setNTRIP_mount + " HTTP/" + htt + "\r\n";
                    str += "User-Agent: NTRIP AgOpenGPSClient/6.4\r\n";
                    str += "Authorization: Basic " + auth + "\r\n"; //This line can be removed if no authorization is needed
                                                                    //str += GGASentence; //this line can be removed if no position feedback is needed
                    str += "Accept: */*\r\nConnection: close\r\n";
                    str += "\r\n";

                    // Convert to byte array and send.
                    Byte[] byteDateLine = Encoding.ASCII.GetBytes(str.ToCharArray());
                    clientSocket.Send(byteDateLine, byteDateLine.Length, 0);

                    //enable to periodically send GGA sentence to server.
                    if (Settings.IO.setNTRIP_sendGGAInterval > 0)
                    {
                        int period = Settings.IO.setNTRIP_sendGGAInterval * 1000;
                        try { tmr?.Change(period, period); } catch (Exception) { }
                    }
                }
                //say its connected
                isNTRIP_Connected = true;
                isNTRIP_Starting = false;
                isNTRIP_Connecting = false;
            }
            catch (Exception ex)
            {
                ReconnectRequest();
                Log.EventWriter("Catch - > NTRIP Send Authourization: " + ex.ToString());
            }
        }

        public void OnAddMessage(byte[] data)
        {
            //reset watchdog since we have updated data
            NTRIP_Watchdog = 0;

            lblToGPS.Text = data.Length.ToString();
            //send it
            SendNTRIP(data);

            //lblToGPS.Text = traffic.cntrGPSInBytes == 0 ? "---" : (traffic.cntrGPSInBytes).ToString();
            traffic.cntrGPSInBytes = 0;
            tripBytes += (uint)data.Length;
        }

        public void SendNTRIP(byte[] data)
        {
            //serial send out GPS port
            if (Settings.IO.setNTRIP_sendToSerial)
            {
                SendGPSPort(data);
            }

            //send out UDP Port
            if (Settings.IO.setNTRIP_sendToUDP)
            {
                SendUDPMessage(data, epNtrip);
            }
        }

        public async Task SendGGAAsync()
        {
            //timer may have brought us here so return if not connected
            if (!isNTRIP_Connected)
                return;

            // Check we are connected
            if (clientSocket == null || !clientSocket.Connected)
            {
                ReconnectRequest();
                return;
            }

            try
            {
                isNTRIP_Sending = true;
                BuildGGA();
                string str = sbGGA.ToString();

                Byte[] byteDateLine = Encoding.ASCII.GetBytes(str);

                // Send on a background thread to avoid blocking the caller's thread
                await Task.Run(() => clientSocket.Send(byteDateLine, byteDateLine.Length, 0)).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.EventWriter("Catch - > Send GGA" + ex.ToString());

                ReconnectRequest();
            }
        }

        // Timer callback runs on ThreadPool thread
        private void NTRIPTimerCallback(object state)
        {
            try
            {
                // fire-and-forget async send
                _ = SendGGAAsync();
            }
            catch (Exception ex)
            {
                // swallow to avoid unhandled exceptions from timer
                Log.EventWriter("NTRIP timer callback error: " + ex.ToString());
            }
        }

        private void NTRIPtick(object o, EventArgs e)
        {
            // If the legacy WinForms timer ever gets used, call the async method
            _ = SendGGAAsync();
        }

        public void OnConnect(IAsyncResult ar)
        {
            // Check if we were sucessfull
            try
            {
                if (clientSocket.Connected)
                    clientSocket.BeginReceive(casterRecBuffer, 0, casterRecBuffer.Length, SocketFlags.None, new AsyncCallback(OnRecievedData), null);
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, "Unusual error during Connect!");
            }
        }

        public void OnRecievedData(IAsyncResult ar)
        {
            // Check if we got any data
            try
            {
                int nBytesRec = clientSocket.EndReceive(ar);
                if (nBytesRec > 0)
                {
                    byte[] localMsg = new byte[nBytesRec];
                    Array.Copy(casterRecBuffer, localMsg, nBytesRec);

                    BeginInvoke((MethodInvoker)(() => OnAddMessage(localMsg)));
                    clientSocket.BeginReceive(casterRecBuffer, 0, casterRecBuffer.Length, SocketFlags.None, new AsyncCallback(OnRecievedData), null);
                }
                else
                {
                    // If no data was recieved then the connection is probably dead
                    Console.WriteLine("Client {0}, disconnected", clientSocket.RemoteEndPoint);
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
            }
            catch (Exception)
            {
                //MessageBox.Show( this, ex.Message, "Unusual error druing Recieve!" );
            }
        }

        private void NtripPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Check if we got any data
            try
            {
                SerialPort comport = (SerialPort)sender;
                if (comport.BytesToRead < 32) 
                    return;

                int nBytesRec = comport.BytesToRead;

                if (nBytesRec > 0)
                {
                    byte[] localMsg = new byte[nBytesRec];
                    comport.Read(localMsg, 0, nBytesRec);

                    BeginInvoke((MethodInvoker)(() => OnAddMessage(localMsg)));
                }
                else
                {
                    // If no data was recieved then the connection is probably dead
                    // TODO: What can we do?
                }
            }
            catch (Exception)
            {
                //MessageBox.Show( this, ex.Message, "Unusual error druing Recieve!" );
            }
        }

        private string ToBase64(string str)
        {
            Encoding asciiEncoding = Encoding.ASCII;
            byte[] byteArray = new byte[asciiEncoding.GetByteCount(str)];
            byteArray = asciiEncoding.GetBytes(str);
            return Convert.ToBase64String(byteArray, 0, byteArray.Length);
        }

        private void ShutDownNTRIP()
        {
            if (clientSocket != null && clientSocket.Connected)
            {
                //shut it down
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
                System.Threading.Thread.Sleep(500);

                //start it up again
                ReconnectRequest();

                //Also stop the requests now
                Settings.IO.setNTRIP_isOn = false;
            }
        }

        private void SettingsShutDownNTRIP()
        {
            if (clientSocket != null && clientSocket.Connected)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
                System.Threading.Thread.Sleep(500);
                ReconnectRequest();
            }
        }

        //calculate the NMEA checksum to stuff at the end
        public string CalculateChecksum(string Sentence)
        {
            int sum = 0, inx;
            char[] sentence_chars = Sentence.ToCharArray();
            char tmp;

            // All character xor:ed results in the trailing hex checksum
            // The checksum calc starts after '$' and ends before '*'
            for (inx = 1; ; inx++)
            {
                tmp = sentence_chars[inx];

                // Indicates end of data and start of checksum
                if (tmp == '*')
                    break;
                sum ^= tmp;    // Build checksum
            }

            // Calculated checksum converted to a 2 digit hex string
            return String.Format("{0:X2}", sum);
        }

        private readonly StringBuilder sbGGA = new StringBuilder();

        private void BuildGGA()
        {
            double latitude = 0;
            double longitude = 0;

            if (Settings.IO.setNTRIP_isGGAManual)
            {
                latitude = Settings.IO.setNTRIP_manualLat;
                longitude = Settings.IO.setNTRIP_manualLon;
            }
            else
            {
                latitude = this.pn.latitude;
                longitude = this.pn.longitude;
            }

            //convert to DMS from Degrees
            double latMinu = latitude;
            double longMinu = longitude;

            double latDeg = (int)latitude;
            double longDeg = (int)longitude;

            latMinu -= latDeg;
            longMinu -= longDeg;

            latMinu = Math.Round(latMinu * 60.0, 7);
            longMinu = Math.Round(longMinu * 60.0, 7);

            latDeg *= 100.0;
            longDeg *= 100.0;

            double latNMEA = latMinu + latDeg;
            double longNMEA = longMinu + longDeg;

            char NS = 'W';
            char EW = 'N';
            if (latitude >= 0) NS = 'N';
            else NS = 'S';
            if (longitude >= 0) EW = 'E';
            else EW = 'W';

            sbGGA.Clear();
            sbGGA.Append("$GPGGA,");
            sbGGA.Append(DateTime.Now.ToString("HHmmss.00,", CultureInfo.InvariantCulture));
            sbGGA.Append(Math.Abs(latNMEA).ToString("0000.000", CultureInfo.InvariantCulture)).Append(',').Append(NS).Append(',');
            sbGGA.Append(Math.Abs(longNMEA).ToString("00000.000", CultureInfo.InvariantCulture)).Append(',').Append(EW);
            sbGGA.Append(',').Append(pn.fixQuality.ToString()).Append(',');
            sbGGA.Append(pn.satellitesTracked.ToString()).Append(',');

            if (pn.hdop > 0) sbGGA.Append(pn.hdop.ToString("0.##", CultureInfo.InvariantCulture)).Append(',');

            else sbGGA.Append("1,");

            sbGGA.Append(pn.altitude.ToString("0.###", CultureInfo.InvariantCulture)).Append(',');
            sbGGA.Append("M,");
            sbGGA.Append("46.4,M,");  //udulation
            sbGGA.Append(pn.age.ToString("0.#", CultureInfo.InvariantCulture)).Append(','); //age
            sbGGA.Append("0*");

            sbGGA.Append(CalculateChecksum(sbGGA.ToString()));
            sbGGA.Append("\r\n");
            /*
        $GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M,5,0*47
           0     1      2      3    4      5 6  7  8   9    10 11  12 13  14
                Time      Lat       Lon     FixSatsOP Alt */
        }
    }
}