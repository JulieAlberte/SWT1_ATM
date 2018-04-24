//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TransponderReceiverSystem.Classes;

namespace TransponderReceiverSystem.UnitTest
{
    [TestFixture]
    class TrackValidationTest
    {
        //Tester nordelige punkter 
        [Test]
        public void ValidateTrack_NorthwestWithMaxAltitude_returnsTrue()
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack(10000, 90000, 20000), Is.EqualTo(true));
        }

        [Test]
        public void ValidateTrack_NorthwestWithMinAltitude_returnsTrue()
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack(10000,90000,500));
        }

        [Test]
        public void ValidateTrack_NortheastWithMaxAltitude_returnsTrue()
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack(90000,90000,20000), Is.EqualTo(true));
        }

        [Test]
        public void ValidateTrack_NortheastWithMinAltitude_returnsTrue()
        {
            var uut= new TrackValidation();
            Assert.That(uut.ValidateTrack(90000,90000,500), Is.EqualTo(true));
        }

        //Tester sydelige punkter

        [TestCase(10000,10000,20000, true)] //max altitude
        [TestCase(10000,10000,500, true)] // min altitude
        public void ValidateTrack_SouthwestWithMaxandMinAltitude_returnsTrue(int xCor, int yCor, int alt, bool result)
        {
            var uut=new TrackValidation();
            Assert.That(uut.ValidateTrack(xCor, yCor, alt), Is.EqualTo(result));
        }

        [TestCase(90000, 10000, 20000, true)] //max altitude
        [TestCase(90000, 10000, 500, true)] //min altitude
        public void ValidateTrack_SoutheastWithMaxandMinAltitude_returnsTrue(int xCor, int yCor, int alt,
            bool result)
        {
            var uut=new TrackValidation();
            Assert.That(uut.ValidateTrack(xCor, yCor, alt), Is.EqualTo(result));
        }

        //nu tjekkes der validation kan validere om fly er undenfor arealet 
        [TestCase(9999,91000,20001, false)] //max altitude over max samt uden for nordvest punkt
        [TestCase(9999, 91000, 499, false)] //min altitude under min
        public void ValidateTrack_NorthwestWithMaxandMinAltitude_returnsFalse(int xCor, int yCor, int alt,
            bool result)
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack(xCor, yCor, alt), Is.EqualTo(result));
        }

        [TestCase(90001, 90001, 20001, false)] //max altitude over max samt uden for nordsyd punkt
        [TestCase(90001, 90001, 499, false)] //min altitude under min
        public void ValidateTrack_NortheastWithMaxandMinAltitude_returnsFalse(int xCor, int yCor, int alt,
            bool result)
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack(xCor, yCor, alt), Is.EqualTo(result));
        }

        [TestCase(9999, 9999, 20001, false)] //max altitude over max samt uden for sydvest punkt
        [TestCase(9999, 9999, 499, false)] //min altitude under min

        public void ValidateTrack_SouthwestWithMaxandMinAltitude_returnsFalse(int xCor, int yCor, int alt,
            bool result)
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack(xCor, yCor, alt), Is.EqualTo(result));
        }

        [TestCase(90001, 9999, 20001, false)] //max altitude over max samt uden for sydøst punkt
        [TestCase(90001, 9999, 499, false)]

        public void ValidateTrack_SoutheastWithMaxandMinAltitude_returnsFalse(int xCor, int yCor, int alt,
            bool result)
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack(xCor, yCor, alt), Is.EqualTo(result));
        }

        // nu testes der for flyet der er inde i vores areal mål
        [TestCase(30000, 80000, 15000, true)] //max altitude over max samt uden for nordvest punkt
        [TestCase(20000, 74890, 520, true)] //min altitude under min
        public void ValidateTrack_NorthwestWithMaxandMinAltitudeInArea_returnsTrue(int xCor, int yCor, int alt,
            bool result)
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack(xCor, yCor, alt), Is.EqualTo(result));
        }

        [TestCase(80000, 68900, 16000, true)] //max altitude over max samt uden for nordsyd punkt
        [TestCase(70000, 80000, 520, true)] //min altitude under min
        public void ValidateTrack_NortheastWithMaxandMinAltitudeInArea_returnsTrue(int xCor, int yCor, int alt,
            bool result)
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack(xCor, yCor, alt), Is.EqualTo(result));
        }

        [TestCase(12000, 10000, 10000, true)] //max altitude over max samt uden for sydvest punkt
        [TestCase(10000, 19999, 550, true)] //min altitude under min

        public void ValidateTrack_SouthwestWithMaxandMinAltitudeInArea_returnsTrue(int xCor, int yCor, int alt,
            bool result)
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack(xCor, yCor, alt), Is.EqualTo(result));
        }

        [TestCase(80000, 15000, 18888, true)] //max altitude over max samt uden for sydøst punkt
        [TestCase(80001, 10000, 600, true)]

        public void ValidateTrack_SoutheastWithMaxandMinAltitudeInArea_returnsFalse(int xCor, int yCor, int alt,
            bool result)
        {
            var uut = new TrackValidation();
            Assert.That(uut.ValidateTrack(xCor, yCor, alt), Is.EqualTo(result));
        }

    }
}


