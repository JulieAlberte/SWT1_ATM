using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ATMClasses.Data;
using ATMClasses.Calculate;
using ATMClasses.Calculate.Interface;
using Castle.DynamicProxy.Generators;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    class CourseTest
    {
        private TrackData _track1;
        private TrackData _track2;
        
        private ICalculateCourse _uut; //Unit under test

        [SetUp]
        public void SetUp()
        {
            _uut = new CalculateCourse();

            _track1 = new TrackData
            {
                Tag = "ABC123",
                X = 90000,
                Y = 90000

            };

            _track2 = new TrackData()
            {
                Tag = "ABC123",
                X = 10000,
                Y = 10000
            };
            
        }

        [Test]
        public void CalculateCourse_SWCorner()
        {
            _uut.CalCourse(_track1,_track2);
            Assert.That(Math.Round(_track2.Course),Is.EqualTo(225));
        }

        [Test]
        public void CalculateCourse_NECorner()
        {

        }





    }
}
