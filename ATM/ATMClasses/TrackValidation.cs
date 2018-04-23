using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    class TrackValidation
    {
        private int _minXCoordinate { get; set; }
        private int _maxXCoordinate { get; set; }
        private int _minYCoordinate { get; set; }
        private int _maxYCoordinate { get; set; }
        private int _minAltitude { get; set; }
        private int _maxAltitude { get; set; }

        public TrackValidation(int minXCoordinate, int maxXCoordinate, int minYCoordinate, int maxYCoordinate,
            int minAltitude, int maxAltitude)
        {
            _minXCoordinate = minXCoordinate;
            _maxXCoordinate = maxXCoordinate;
            _minYCoordinate = minYCoordinate;
            _maxYCoordinate = maxYCoordinate;
            _minAltitude = minAltitude;
            _maxAltitude = maxAltitude;
        }

        public TrackValidation()
        {
            _minXCoordinate = 10000;
            _maxXCoordinate = 90000;
            _minYCoordinate = 10000;
            _maxYCoordinate = 90000;
            _minAltitude = 500;
            _maxAltitude = 20000;
        }

        public bool ValidateTrack(int xcoordinate, int ycoordinate, int altitude)
        {
            //int xCoordinate = int.Parse(xcoordinate);
            //int yCoordinate = int.Parse(ycoordinate);
            //int aAltitude = int.Parse(altitude);

            if (xcoordinate >= _minXCoordinate && xcoordinate <= _maxXCoordinate
                                               && ycoordinate >= _minYCoordinate && ycoordinate <= _maxYCoordinate
                                               && altitude >= _minAltitude && altitude <= _maxAltitude)
            {
                return true;
            }

            return false;
        }
    }
}
