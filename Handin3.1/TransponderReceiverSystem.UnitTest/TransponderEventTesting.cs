using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace TransponderReceiverSystem.UnitTest
{
    [TestFixture]
    public class TransponderEventTesting
    {
        //Transponderreceiver must be substituted so we can test the events
        private ITransponderReceiver _transponderReceiver;
        private List<string> _rightInfoList;
        private List<string> _wrongInfoList;

        [SetUp]
        public void setup()
        {
            //Substutute the transponder
            _transponderReceiver = Substitute.For<ITransponderReceiver>();

            //Giver manuelt stringen informationer
            _rightInfoList = new List<string> { "ATR423;39045;12932;14000;20151006213456789" };

        }

        [Test]
        public void TransponderReady_RaiseEvent_EventReceived()
        {
            var args = new RawTransponderDataEventArgs(_rightInfoList);
            //Rasises a transponder event with "args" from infoList
            _transponderReceiver.TransponderDataReady += Raise.EventWith(args);

            //After we test the execepted event is received
            Assert.That(args.TransponderData, Is.EqualTo(_rightInfoList));
        }

        [Test]
        public void TransponderReady_RaiseEvent_DataNotEqual()
        {
            _wrongInfoList = new List<string> { "ABC123;30000;12000;15000;20180410213456789" };

            var args = new RawTransponderDataEventArgs(_rightInfoList);
            _transponderReceiver.TransponderDataReady += Raise.EventWith(args);

            Assert.AreNotEqual(args.TransponderData, _wrongInfoList);

        }
    }
}