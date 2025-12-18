namespace Twol
{
    public class CAHRS
    {
        //private readonly FormGPS mf;

        //Roll and heading from the IMU
        public double imuHeading = 99999, prevIMUHeading = 0, imuRoll = 0, imuPitch = 0, imuYawRate = 0;
        public double imuToolHeading = 99999, prevIMUToolHeading = 0, imuToolRoll = 0, imuToolPitch = 0, imuToolYawRate = 0;

        public System.Int16 angVel;

        public double angularVehicleVelocity = 0;

        //constructor
        public CAHRS()
        {
        }
    }
}