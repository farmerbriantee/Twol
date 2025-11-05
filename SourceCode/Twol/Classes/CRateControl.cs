using OpenTK.Graphics.OpenGL;

namespace Twol
{
    public class CRateControlData
    {
        public uint rateActualx10;
        public uint rateSetx10;
        public uint volumeApplied;
        public int volumeRemain;
        public int coveragePossiblex10;
        public uint sensor;
        public int channel;
        public bool isAlarming; //0 is not alarm, 1 is alarm
        public bool isChannelActive; //0 is not alarm, 1 is alarm

        public CRateControlData()
        {
            rateActualx10 = 88;
            rateSetx10 = 99;
            volumeApplied = 600;
            volumeRemain = 300;
            coveragePossiblex10 = 325;
            sensor = 500;
            channel = 0;
            isAlarming = false;
            isChannelActive = false;
        }
    }

    public class CRateControlConfig
    {
        public string productName0; //gal/ac - lbs/ac L/Ha etc
        public string productName1; //gal/ac - lbs/ac L/Ha etc
        public string productName2; //gal/ac - lbs/ac L/Ha etc
        public string productName3; //gal/ac - lbs/ac L/Ha etc

        public string units0; //gal/ac - lbs/ac L/Ha etc
        public string units1; //gal/ac - lbs/ac L/Ha etc
        public string units2; //gal/ac - lbs/ac L/Ha etc
        public string units3; //gal/ac - lbs/ac L/Ha etc

        public int isFanPressure0; //0 = neither, 1 = fan, 2 = pressure
        public int isFanPressure1;
        public int isFanPressure2;
        public int isFanPressure3;

        public bool[] isActive;

        public CRateControlConfig()
        {
            productName0 = "One";
            productName1 = string.Empty;
            productName2 = string.Empty;
            productName3 = string.Empty;

            units0 = "lb/ac";
            units1 = string.Empty;
            units2 = string.Empty;
            units3 = string.Empty;

            isFanPressure0 = 1; //0 neither - Fan=1 Pressure=2
            isFanPressure1 = 0; //0 neither - Fan=1 Pressure=2
            isFanPressure2 = 0; //0 neither - Fan=1 Pressure=2
            isFanPressure3 = 0; //0 neither - Fan=1 Pressure=2

            isActive = new bool[4] { false, false, false, false };
        }
    }
}