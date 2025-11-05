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
            rateActualx10 = 0;
            rateSetx10 = 0;
            volumeApplied = 0;
            volumeRemain = 0;
            coveragePossiblex10 = 0;
            sensor = 0;
            isAlarming = false;
            channel = 0;
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
            productName0 = string.Empty;
            productName1 = string.Empty;
            productName2 = string.Empty;
            productName3 = string.Empty;

            units0 = string.Empty;
            units1 = string.Empty;
            units2 = string.Empty;
            units3 = string.Empty;

            isFanPressure0 = 0; //0 neither - Fan=1 Pressure=2
            isFanPressure1 = 0; //0 neither - Fan=1 Pressure=2
            isFanPressure2 = 0; //0 neither - Fan=1 Pressure=2
            isFanPressure3 = 0; //0 neither - Fan=1 Pressure=2

            isActive = new bool[4] { true, true, true, true };
        }
    }
}