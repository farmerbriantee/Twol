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
}
