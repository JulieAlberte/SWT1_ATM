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
        public List<TrackOjects> TrackObjectList { get; private set; }

        public TransponderObserverSoftware()
        {
            var transponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            transponderReceiver.TransponderDataReady+= TransponderReceiverOnTransponderDataReady;
        }

        private void TransponderReceiverOnTransponderDataReady(object sender,
            RawTransponderDataEventArgs rawTransponderDataEventArgs)
        {
            List<string> values = rawTransponderDataEventArgs.TransponderData;
            CreateTrackObject(values);
        }

        public void CreateTrackObject(List<string> values)
        {
            ITrackValidation myTackValidation = new TrackValidation();
            ITrackFormation myTrackFormation = new TrackFormation();

            foreach (var value in values)
            {
                string[] data = TrackParser.ParseString(value);
                if (myTackValidation.ValidateTrack(data[1], data[2], data[3]))
                {
                    Console.WriteLine("something");
                    //data[4] = myTrackFormation.FormatTimestamp(data[4]);
                    TrackOjects td = new TrackOjects(data[0], data[1], data[2], data[3], data[4]);
                    TrackObjectList.Add(td);
                }
                else
                {
                    //Console.WriteLine("Not in area");
                }
            }
        }
    }
}
