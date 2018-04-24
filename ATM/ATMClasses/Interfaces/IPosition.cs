using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    public interface IPosition
    {
        int X { get; }
        int Y { get; }
        int Altitude { get; }
        void SetPosition(int x, int y, int altitude);
    }
}


