using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ATMClasses;
using ATMClasses.Data;
using ATMClasses.Interfaces;
using NUnit.Framework.Internal;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    class SeperationTest
    {

        private ITrackSeperation uut;
        private SeperationEventData seperationEventData;
        private FileLog fileLog;
        private List<TrackData> trackDataList;
        private DateTime dateTime1;
        private DateTime dateTime2;
        private DateTime dateTime3; 
        private TrackData track1;
        private TrackData track2;
        private TrackData track3; 




        [SetUp]
        public void SetUp()
        {
            seperationEventData = new SeperationEventData();
            fileLog = new FileLog();

            uut = new TrackSeperation(seperationEventData, fileLog);


            dateTime1 = new DateTime(2018, 4, 24, 12, 15, 12);
            dateTime2 = new DateTime(2018, 4, 24, 12, 15, 14);
            dateTime3 = new DateTime(2018, 4, 24, 12, 15, 18);


            track1 = new TrackData
            {
                Tag = "ABC123",
                X = 24682, 
                Y = 13579,
                Altitude = 15000,
                Timestamp = dateTime1

            };


            track2 = new TrackData
            {
                Tag = "QWE123",
                X = 24684,
                Y = 13453,
                Altitude = 15001,
                Timestamp = dateTime2

            };



            track3 = new TrackData
            {
                Tag = "DFG123",
                X = 34684,
                Y = 56453,
                Altitude = 17000,
                Timestamp = dateTime2

            };



            trackDataList = new List<TrackData>
            {
                track1, track2, track3
            };

        }


        [Test]
        public void CheckForSeperationTest_VerticalSeperation_LogToFile()
        {
            uut.CheckForSeperation(trackDataList);
            fileLog.Received().LogToFile(Arg.Is<List<SeperationEventData>>((x) => x[0].TAG1 == "ABC123" && x[0].TAG2== "QWE123"));
        }





    }
}
