using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Interfaces;

namespace ATMClasses
{
    public class Position: IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Altitude { get; set; }

        public void SetPosition(int x, int y, int altitude)
        {
            X = x;
            Y = y;
            Altitude = altitude;
        }
    }
}
