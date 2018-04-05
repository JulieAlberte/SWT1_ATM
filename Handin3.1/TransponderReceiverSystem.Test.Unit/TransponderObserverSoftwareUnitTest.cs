using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TransponderReceiverSystem.Test.Unit
{
    [TestFixture]
    [Author("SWTTeam 1")]
    public class TransponderObserverSoftwareUnitTest
    {
        private TransponderObserverSoftware _uut;
        
        [SetUp]
        public void Setup()
        {
            _uut = new TransponderObserverSoftware();
            _uut.TransponderReceiverOnTransponderDataReady += (object, args) => { };
        }

        public void 

    }
}
