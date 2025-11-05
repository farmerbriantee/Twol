namespace Twol
{
    public class CRateControlData
    {
        public uint rateActualx10 = 0;
        public uint rateSetx10 = 0;
        public uint volumeApplied = 0;
        public int volumeRemain = 0;
        public int coveragePossiblex10 = 0;
        public uint fanspeed = 0;
        public uint pressure = 0;
        public byte isAlarming = 0;
        public byte channel = 0;
    }

    public class CRateControl_Config
    {
        public string units0 = string.Empty; //gal/ac - lbs/ac L/Ha etc
        public string units1 = string.Empty; //gal/ac - lbs/ac L/Ha etc
        public string units2 = string.Empty; //gal/ac - lbs/ac L/Ha etc
        public string units3 = string.Empty; //gal/ac - lbs/ac L/Ha etc

        public int rateAlarmPercent0 = 0;
        public int rateAlarmPercent1 = 0;
        public int rateAlarmPercent2 = 0;
        public int rateAlarmPercent3 = 0;

        public string productName0 = string.Empty; //gal/ac - lbs/ac L/Ha etc
        public string productName1 = string.Empty; //gal/ac - lbs/ac L/Ha etc
        public string productName2 = string.Empty; //gal/ac - lbs/ac L/Ha etc
        public string productName3 = string.Empty; //gal/ac - lbs/ac L/Ha etc

        public byte isFan0 = 0;
        public byte isFan1 = 0;
        public byte isFan2 = 0;
        public byte isFan3 = 0;

        public byte isPressure0 = 0;
        public byte isPressure1 = 0;
        public byte isPressure2 = 0;
        public byte isPressure3 = 0;
    }
}
