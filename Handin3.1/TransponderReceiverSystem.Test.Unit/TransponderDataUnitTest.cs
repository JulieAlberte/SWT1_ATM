using System;
using System.Collections.Generic;
using TransponderReceiverSystem;
using NUnit.Framework;

namespace TransponderReceiverSystem.Test.Unit
{
    [TestFixture]
    [Author("SWTTeam1")]
    public class TransponderDataUnitTest
    {
        private TransponderData _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new TransponderData();
        }
    }
}
