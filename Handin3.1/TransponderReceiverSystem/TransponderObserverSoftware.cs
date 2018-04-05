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
            List<string> values = rawTransponderDataEventArgs.TransponderData;
            foreach (var value in values)
            {
                string[] data = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                TransponderData td = new TransponderData(data[0], data[1], data[2], data[3], data[4]);
            }
        }
    }
}
