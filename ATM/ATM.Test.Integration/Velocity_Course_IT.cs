using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses;
using ATMClasses.Calculate;
using ATMClasses.Data;
using ATMClasses.Interfaces;
using NUnit.Framework;
using NSubstitute;
using TransponderReceiver;

namespace ATM.Test.Integration
{
    [TestFixture]
    class Velocity_Course_IT
    {
        private ITransponderReceiver _transponderReceiver;
        private RawTransponderDataEventArgs _fakeEventArgs1;
        private RawTransponderDataEventArgs _fakeEventArgs2;

        private CalculateCourse _cc;
        private CalculateVelocity _cv;

        private List<TrackData> _trackList;
        private TrackData trackData;

        [SetUp]
        public void SetUp()
        {
            _transponderReceiver = Substitute.For<ITransponderReceiver>();
            _cc = new CalculateCourse();
            _cv = new CalculateVelocity();
            trackData = new TrackData();

            _fakeEventArgs1 = new RawTransponderDataEventArgs(new List<string>()
            {
                "FLY1;88000;88000;6000;20180420222222222"
                //"FLY2;72000;91000;19999;20180420222222222",
                //"FLY3;86000;86000;6500;20180420222222222"
            });

            _fakeEventArgs2 = new RawTransponderDataEventArgs(new List<string>()
            {
                "FLY1;86000;86000;6000;20180420223222222"
                //"FLY2;72000;91000;19999;20180420223222222",
                //"FLY3;86000;86000;6500;20180420223222222"
            });

            
            
        }

        [Test]
        public void CalculateVelocity_CorrectVelocity()
        {
            _transponderReceiver.TransponderDataReady += Raise.EventWith(_fakeEventArgs1);
            _transponderReceiver.TransponderDataReady += Raise.EventWith(_fakeEventArgs2);

            Assert.That(Math.Round(trackData.Velocity, 2), Is.EqualTo(4.71));

        }

        [Test]
        public void CalculateCourse_CorrectCourse()
        {
            _transponderReceiver.TransponderDataReady += Raise.EventWith(_fakeEventArgs1);
            _transponderReceiver.TransponderDataReady += Raise.EventWith(_fakeEventArgs2);

            Assert.That(trackData.Course, Is.EqualTo(45));

        }


    }
}
