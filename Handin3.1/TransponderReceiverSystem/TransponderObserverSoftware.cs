using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace TransponderReceiverSystem
{
    public class TransponderObserverSoftware
    {
        public TransponderObserverSoftware()
        {
            var transponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            transponderReceiver.TransponderDataReady+= TransponderReceiverOnTransponderDataReady;
        }

        private void TransponderReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs rawTransponderDataEventArgs)
        {
            string[] data = { };
            List<string> values = rawTransponderDataEventArgs.TransponderData;
            data = ParseString(values);

            if (ValidateTrack(data))
            {
                TrackOjects td = new TrackOjects(data[0], data[1], data[2], data[3], data[4]);
            }
            //else nothing ??
        }

        public string[] ParseString(List<string> values)
        {
            string[] data = {};
            string[] separators = { ";" };
            foreach (var value in values)
            {
                data = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            }
            return data;
        }
        public bool ValidateTrack(string[] data)
        {
            int minXCoordinate = 10000;
            int maxXCoordinate = 90000;
            int minYCoordinate = 10000;
            int maxYCoordinate = 90000;
            int minAltitue = 500;
            int maxAltitude = 20000;

            if (int.Parse(data[1]) > minXCoordinate & int.Parse(data[1]) < maxXCoordinate & )
            {

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
