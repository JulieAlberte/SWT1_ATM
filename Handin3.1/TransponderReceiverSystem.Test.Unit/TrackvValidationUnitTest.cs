using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransponderReceiverSystem;

namespace TransponderReceiverSystem.Test.Unit
{
    [TestFixture]
    class TrackvValidationUnitTest
    {
        [Test]

        public void ValidateTrack_xCoordinate9000Ycoordinate1000Altitude550_returnsTrue()
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack("9000","1000","550"), Is.EqualTo(true));
        }



     

    }
}
