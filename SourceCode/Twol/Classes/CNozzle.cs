namespace Twol
{
    public class CNozzle
    {
        //pointers to mainform controls Nozzz
        private readonly FormGPS mf;

        public double currentWidthMeters = 0;

        public double rateSetSelected = 0;

        public double rateActualFiltered = 0;

        public string[] rateTextArr = new string[4] { " L/ha", " Kg/ha", " GPA", " lb/ac" };
        public string[] unitsTextArr = new string[4] { " Liters", " Kgs", " Gallons", " Pounds" };

        public int rateSet = 0;
        public int rateActual = 0;
        public double frequency = 0;

        public int pressureActual = 0;

        public bool isFlowingFlag = false;

        public int pwmDriveActual = 0;
        public bool isAutoMode = true;

        public double unitsAppliedLast = 0;

        public int percentWidthBypass = 1;

        public CNozzle(FormGPS _f)
        {
            //constructor
            mf = _f;
            rateSetSelected = Settings.Tool.setNozz.rateSet1;
        }

        public void BuildRatePGN()
        {
            mf.nozz.rateSet = 0;
            mf.nozz.currentWidthMeters = 0;

            for (int i = 0; i < mf.section.Count; i++)
            {
                if (mf.section[i].isSectionOn)
                {
                    mf.nozz.currentWidthMeters += mf.section[i].sectionWidth;
                }
            }

            mf.nozz.percentWidthBypass = (int)(mf.nozz.currentWidthMeters / Settings.Tool.toolWidth * 100);

            if (Settings.Tool.setNozz.isBypass)
            {
                mf.nozz.currentWidthMeters = Settings.Tool.toolWidth;
            }

            if (mf.nozz.currentWidthMeters != 0)
            {
                if (Settings.User.isMetric)
                {
                    //Liters * 0.00167 𝑥 𝑠𝑤𝑎𝑡ℎ 𝑤𝑖𝑑𝑡ℎ 𝑥 𝐾mh * ( to send as integer x100)
                    mf.nozz.rateSet =
                        (int)(mf.nozz.rateSetSelected * 0.167 * mf.nozz.currentWidthMeters * mf.avgSpeed);
                }
                else
                {
                    //calculate gallons per minute - GPM = GPA X MPH X Width (in inches)/ 5,940
                    mf.nozz.rateSet = (int)(mf.nozz.rateSetSelected *
                                                    (mf.avgSpeed * glm.kmhToMphOrKmh) * mf.nozz.currentWidthMeters * glm.m2InchOrCm / 5940 * 100);
                }

                PGN_227.pgn[PGN_227.volumePerMinuteSetLo] = (byte)(mf.nozz.rateSet);
                PGN_227.pgn[PGN_227.volumePerMinuteSetHi] = unchecked((byte)((mf.nozz.rateSet) >> 8));
                PGN_227.pgn[PGN_227.percentWidthBypass] = (byte)(mf.nozz.percentWidthBypass);
            }
            else
            {
                mf.nozz.rateSet = 0;

                PGN_227.pgn[PGN_227.volumePerMinuteSetLo] = 0;
                PGN_227.pgn[PGN_227.volumePerMinuteSetHi] = 0;
                PGN_227.pgn[PGN_227.percentWidthBypass] = 0;
            }

            PGN_227.pgn[PGN_227.sec1to8] = PGN_254.pgn[PGN_254.sc1to8];
            PGN_227.pgn[PGN_227.sec9to16] = PGN_254.pgn[PGN_254.sc9to16];

            PGN_227.pgn[PGN_227.speed] = (byte)(mf.avgSpeed * 10);


            mf.SendUDPMessage(PGN_227.pgn, mf.epModule);
        }
    }

    public class CNozzleSettings
    {
        //used in Properties.settings.settings
        public CNozzleSettings()
        { }

        public double rateSet1 = 6;
        public double rateSet2 = 12;

        public int unitsIdx = 0;

        // 1 bar = 14.5 psi
        public double pressureMax = 100;
        public double pressureMin = 1;

        //counts per 10 units of flow
        public int calNumber = 3300;

        public int pressureCal = 1;

        public byte Kp = 1;
        public byte Ki = 1;

        public byte fastPWM = 100;
        public byte slowPWM = 50;

        public byte deadbandError = 5;

        public byte switchAtRateError = 20;

        public double rateAlarmPercent = 0.1;

        //manual function up down rate
        public byte manualRate = 50;

        public bool isBypass = false;
        public bool isMeter = false;

        public double unitsApplied = 0;
        public int unitsTankStart = 0;

        public bool isAppliedUnitsNotTankDisplayed = true;

        public double rateNudge = 1;

        public bool isSectionValve3Wire = true;
    }
}