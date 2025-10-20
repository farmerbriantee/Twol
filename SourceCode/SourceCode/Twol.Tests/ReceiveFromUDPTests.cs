using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using Twol;

namespace Twol.Tests
{
    [TestClass]
    public class ReceiveFromUDPTests
    {
        [TestMethod]
        public void ReceiveFromUDP_ProcessesNMEASentence_UpdatesPN()
        {
            // Arrange
            var form = new FormGPS();

            // Prepare a simple GPGGA NMEA sentence with checksum
            string nmea = "$GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M,,*47\r\n";
            byte[] data = Encoding.ASCII.GetBytes(nmea);

            // Act
            form.ReceiveFromUDP(data, data.Length);

            // Assert
            Assert.IsTrue(form.pn.isNMEAToSend || form.pn.rawBuffer.Length > 0);
        }
    }
}
