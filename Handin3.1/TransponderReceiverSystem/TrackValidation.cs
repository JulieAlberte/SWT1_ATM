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
        
        public bool ValidateTrack(string xcoordinate, string ycoordinate, string altitude)
        {
            int x_coordinate = int.Parse(xcoordinate);
            int y_coordinate = int.Parse(ycoordinate);
            int a_altitude = int.Parse(altitude);

            if (x_coordinate > _minXCoordinate && x_coordinate < _maxXCoordinate
                && y_coordinate > _minYCoordinate && y_coordinate < _maxYCoordinate
                && a_altitude > _minAltitue && a_altitude < _maxAltitude)
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