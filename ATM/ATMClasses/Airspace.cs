using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Interfaces;

namespace ATMClasses
{
    public class Airspace: IAirspace
    {
        public int _east;
        public int _west;
        public int _north;
        public int _south;
        public int _lower;
        public int _upper;


        public Airspace() : this(90000, 10000, 90000, 10000, 500, 20000)
        { }

        private Airspace(int E, int W, int N, int S, int L, int U)
        {
            _east = E;
            _west = W;
            _north = N;
            _south = S;
            _lower = L;
            _upper = U;
        }

        public bool InValidAirspace(ITrackDecoding track)
        {
            throw new NotImplementedException();
        }
    }
}
