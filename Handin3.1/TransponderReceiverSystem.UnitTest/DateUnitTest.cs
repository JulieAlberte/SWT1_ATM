//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TransponderReceiverSystem;

namespace TransponderReceiverSystem.UnitTest
{
    [TestFixture]
    class DateUUnitTest
    {

        [TestCase("20151006213456789","October 6th, 2015, at 21:34:56 and 789 milliseconds")]
        public void ValidateTimeStamp_returnsTrue(string a, string result)
        {
            var uut = new TrackFormation();
            Assert.That(uut.FormatTimestamp(a), Is.EqualTo(result));

        }
    }
} 