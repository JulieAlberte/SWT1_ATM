using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverSystem
{
    class TrackValidation
    {
        private int _minXCoordinate { get; set; }
        private int _maxXCoordinate { get; set; }
        private int _minYCoordinate { get; set; }
        private int _maxYCoordinate { get; set; }
        private int _minAltitue { get; set; }
        private int _maxAltitude { get; set; }

        TrackValidation(int minXCoordinate, int maxXCoordinate, int minYCoordinate, int maxYCoordinate, int minAltitude, int maxAltitude)
        {
            _minXCoordinate = minXCoordinate;
           

        }
        public bool ValidateTrack(string[] data)
        {
            
            int x_coordinate = int.Parse(data[1]);
            int y_coordinate = int.Parse(data[2]);
            int altitude = int.Parse(data[3]);

            if (x_coordinate > minXCoordinate & x_coordinate < maxXCoordinate &)
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