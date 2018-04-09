//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TransponderReceiverSystem;

namespace TransponderReceiverSystem.UnitTest
{
    [TestFixture]
    class TrackvValidationUnitTest
    {
        //Tester nordelige punkter 
        [Test]
        public void ValidateTrack_NorthwestWithMaxAltitude_returnsTrue()
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack("10000", "90000", "20000"), Is.EqualTo(true));
        }

        [Test]
        public void ValidateTrack_NorthwestWithMinAltitude_returnsTrue()
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack("10000","90000","500"));
        }

        [Test]
        public void ValidateTrack_NortheastWithMaxAltitude_returnsTrue()
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack("90000","90000","20000"), Is.EqualTo(true));
        }

        [Test]
        public void ValidateTrack_NortheastWithMinAltitude_returnsTrue()
        {
            var uut= new TrackValidation();
            Assert.That(uut.ValidateTrack("90000","90000","500"), Is.EqualTo(true));
        }

        //Tester sydelige punkter

        [TestCase("10000","10000","20000", true)] //max altitude
        [TestCase("10000","10000","500", true)] // min altitude
        public void ValidateTrack_SouthwestWithMaxandMinAltitude_returnsTrue(string xCor, string yCor, string alt, bool result)
        {
            var uut=new TrackValidation();
            Assert.That(uut.ValidateTrack(xCor, yCor, alt), Is.EqualTo(result));
        }

        [TestCase("90000", "10000", "20000", true)] //max altitude
        [TestCase("90000", "10000", "500", true)] //min altitude
        public void ValidateTrack_SoutheastWithMaxandMinAltitude_returnsTrue(string xCor, string yCor, string alt,
            bool result)
        {
            var uut=new TrackValidation();
            Assert.That(uut.ValidateTrack(xCor, yCor, alt), Is.EqualTo(result));
        }
    }
}


