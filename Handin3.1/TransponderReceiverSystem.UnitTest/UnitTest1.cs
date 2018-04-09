//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TransponderReceiverSystem;

namespace TransponderReceiverSystem.UnitTest
{
    [TestFixture]
    class TrackvValidationUnitTest
    {
        [Test]
        public void ValidateTrack_NordVestPunktmedMaxAltitude_returnsTrue()
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack("10000", "90000", "20000"), Is.EqualTo(true));
        }

        [Test]
        public void ValidateTrack_NordvestpunktmedMinAltitude_returnsTrue()
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack("10000","90000","500"));
        }

        [Test]
        public void ValidateTrack_NordoesttPunktmedMaxAltitude_returnsTrue()
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack("90000","90000","20000"), Is.EqualTo(true));
        }

        [Test]
        public void ValidateTrack_NordoestPunktmedMinAltitude_returnsTrue()
        {
            var uut= new TrackValidation();
            Assert.That(uut.ValidateTrack("90000","90000","500"), Is.EqualTo(true));
        }
    }
}


