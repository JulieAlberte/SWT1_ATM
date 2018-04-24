using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Interfaces;

namespace ATMClasses
{
    public class Airspace : IAirspace
    {

        private readonly int _coorHigher;
        private readonly int _coorLower;
        private readonly int _altHigher;
        private readonly int _altLower;

      
      

        public Airspace(int coorHigher, int coorLower, int altHigher, int altLower)
        {
            _coorHigher = coorHigher;
            _coorLower = coorLower;
            _altHigher = altHigher;
            _altLower = altLower; 
        }

       

        public bool ValidAirspace(IPosition position)
        {
            return ValidAirspaceCoordinates(position.X, position.Y) && ValidAltitude(position.Altitude);
        }

        private bool ValidAirspaceCoordinates(int x, int y)
        {
            return ValidXCoordinate(x) && ValidYCoordinate(y);
        }

        private bool ValidAltitude(int altitude)
        {
            return altitude <= _altHigher && altitude >= _altLower;
        }

        private bool ValidXCoordinate(int x)
        {
            return x <= _coorHigher && x >= _coorLower;

        }

        private bool ValidYCoordinate(int y)
        {
            return y <= _coorHigher && y >= _coorLower;
        }


    }
}
