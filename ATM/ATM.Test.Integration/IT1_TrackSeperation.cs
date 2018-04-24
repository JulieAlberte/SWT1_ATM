using ATMClasses;
using ATMClasses.Data;
using NUnit.Framework;
using NSubstitute;
using TransponderReceiver;

namespace ATM.Test.Integration
{
    [TestFixture]
    public class IT1_TrackSeperation
    {
        private TrackSeperation _uut;
        private TrackData _track1;
        private TrackData _track2;

        [Setup]
        public void SetUp()
        {
            _uut = new TrackSeperation();
            _track1 = new TrackData()
            {
                X = 
                Y = 
                Altitude = 
            }
        }

        [Test]
        public void CheckForSeperation_True()
        {
            _uut.CheckForSeperation();
        }
    }
}