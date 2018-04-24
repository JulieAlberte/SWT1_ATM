using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Data;
using NSubstitute; 
using NUnit.Framework;
using NUnit; 
using ATMClasses;
using ATMClasses.Calculate;
using ATMClasses.Interfaces;
using ATMClasses.Calculate.Interface;
using NUnit.Framework.Internal;

namespace ATM.Unit.Test
{

    [TestFixture]
    class VelocityTest
    {

        private TrackData _track1;
        private TrackData _track2;

        private ICalculateVel _uut;
     
        [SetUp]
        public void SetUp()
        {
            _uut = new CalculateVelocity();
        
            var dateTime = new DateTime(2017, 03, 02, 16, 20, 18);
            var dateTime2 = new DateTime(2017, 03, 02, 16, 20, 20);

            _track1 = new TrackData
            {
                Tag = "ABC123",
                X = 24689,
                Y = 98765,
                Timestamp = dateTime
            };


            _track2 = new TrackData
            {
                Tag = "ABC123",
                X = 13579,
                Y = 56565,
                Timestamp = dateTime2
            };
        }

        [Test]
        public void CalculateVelocityTest()
        {
            _uut.CalVelocity(_track1, _track2);
            Assert.That(Math.Round(_track2.Velocity, 2), Is.EqualTo(21818.98));

        }

    }



       
        
        


        

      


    
}
