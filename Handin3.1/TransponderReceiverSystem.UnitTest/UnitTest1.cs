//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TransponderReceiverSystem;

namespace TransponderReceiverSystem.UnitTest
{
    [TestFixture]
    class TrackvValidationUnitTest
    {
        [Test]
        public void ValidateTrack_NordVestPunktmedmaxAltitude_returnsTrue()
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack("10000", "90000", "20000"), Is.EqualTo(true));
        }

        public void ValidateTrack_NordvestpunktmedminAltitude_returnsTrue()
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack("10000","90000","500"));
        }

        [Test]
        public void ValidateTrack_NordoesttPunkt_returnsTrue()
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack("90000","90000","500"), Is.EqualTo(true));
        }
    }
}


