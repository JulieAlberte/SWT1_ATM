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
using ATMClasses.Interfaces;
using ATMClasses.Calculate.Interface;
using NUnit.Framework.Internal;

namespace ATM.Unit.Test
{

    [TestFixture]
    class VelocityTest
    {
        private ICalculateVel _calculateVel;

        private ITrack oldTrack;
        private ITrack newTrack; 



        [SetUp]
        public void SetUp()
        {
            //_calculateVel = new Velocity();


            oldTrack = Substitute.For<ITrack>();
            newTrack = Substitute.For<ITrack>();
        }


        

      


        [Test]
        public void NoTimeDiff_returnZero()
        {
            int exp = 0; 
            DateTime time = new DateTime(2013, 12, 24, 12, 55, 34, 100);
            DateTime newTime = time; 


            //Assert.AreEqual();
            
        }



    }
}
