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

        private void TransponderReceiverOnTransponderDataReady(object sender,
            RawTransponderDataEventArgs rawTransponderDataEventArgs)
        {
            List<string> values = rawTransponderDataEventArgs.TransponderData;
            CreateTrackObject(values);
        }

        public void CreateTrackObject(List<string> values)
        {
            //TrackParser myTrackParser = new TrackParser();
            TrackValidation myTackTrackValidation = new TrackValidation();

            string[] data = { };
            foreach (string value in values)
            {
                data = TrackParser.ParseString(value);
                if (myTackTrackValidation.ValidateTrack(data[1], data[2], data[3]))
                {
                    TrackOjects td = new TrackOjects(data[0], data[1], data[2], data[3], data[4]);
                }
                else
                {
                    //something
                }

            }
        }

        //string[] data = { };
        //List<string> values = rawTransponderDataEventArgs.TransponderData;
        //foreach (var value in values)
        //{
        //    data = ParseString(value);
        //    if (ValidateTrack(data))
        //    {
        //        data[4] = FormatTimestamp(data[4]);
        //        TrackOjects td = new TrackOjects(data[0], data[1], data[2], data[3], data[4]);
        //    }
        //    //else something
        //}

        //Returns string array
        //public string[] ParseString(string values)
        //{
        //    string[] data = {};
        //    string[] separators = { ";" };
        //    data = values.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        //    return data;
        //}

        ////public bool ValidateTrack(string[] data)
        ////{
        ////    int minXCoordinate = 10000;
        ////    int maxXCoordinate = 90000;
        ////    int minYCoordinate = 10000;
        ////    int maxYCoordinate = 90000;
        ////    int minAltitue = 500;
        ////    int maxAltitude = 20000;
        ////    int x_coordinate = int.Parse(data[1]);
        ////    int y_coordinate = int.Parse(data[2]);
        ////    int altitude = int.Parse(data[3]);

        ////    if (x_coordinate > minXCoordinate & x_coordinate < maxXCoordinate & )
        ////    {

        ////        return true;
        ////    }
        ////    else
        ////    {
        ////        return false;
        ////    }
        ////}

        //public string FormatTimestamp(string timestamp)
        //{

        //    return timestamp;
        //}
    }
}
