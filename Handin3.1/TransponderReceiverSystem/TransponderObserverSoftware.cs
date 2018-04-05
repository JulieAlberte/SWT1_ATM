using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;


namespace TransponderReceiverSystem
{
    class TransponderObserverSoftware
    {
        public TransponderObserverSoftware()
        {
            var transponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            transponderReceiver.TransponderDataReady+= TransponderReceiverOnTransponderDataReady;
        }

        private void TransponderReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs rawTransponderDataEventArgs)
        {
            string[] separators = {";"};
            string value = rawTransponderDataEventArgs.ToString();
            string[] data = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        }
    }
}
