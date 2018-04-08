using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverSystem
{
    public class TrackValidation : ITrackValidation
    {
        private int _minXCoordinate { get; set; }
        private int _maxXCoordinate { get; set; }
        private int _minYCoordinate { get; set; }
        private int _maxYCoordinate { get; set; }
        private int _minAltitue { get; set; }
        private int _maxAltitude { get; set; }

        public TrackValidation(int minXCoordinate, int maxXCoordinate, int minYCoordinate, int maxYCoordinate, int minAltitude, int maxAltitude)
        {
            _minXCoordinate = minXCoordinate;
            _maxXCoordinate = maxXCoordinate;
            _minYCoordinate = minYCoordinate;
            _maxYCoordinate = maxYCoordinate;
            _minAltitue = minAltitude;
            _maxAltitude = maxAltitude;
        }

        public TrackValidation()
        {
            _minXCoordinate = 10000;
            _maxXCoordinate = 90000;
            _minYCoordinate = 10000;
            _maxYCoordinate = 90000;
            _minAltitue = 500;
            _maxAltitude = 20000;
        }
        public bool ValidateTrack(string x_coordinate, string y_coordinate, string altitude)
        {
            //If (indenfor firkant)
            //return true;
            //Hvis ikke
            //Return false
            return true;
        }
        

        
        //static public bool ValidateTrack(string[] data)
        //{
        //    int x_coordinate = int.Parse(data[1]);
        //    int y_coordinate = int.Parse(data[2]);
        //    int altitude = int.Parse(data[3]);

        //    if (x_coordinate > minXCoordinate & x_coordinate < maxXCoordinate &)
        //    {

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}