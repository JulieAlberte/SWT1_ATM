using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Data;

namespace AppWithMethod
{
    class Velocity
    {
        public double CalculateVelocity(TrackData td1, TrackData td2)
        {
            int meters = (td2.X - td1.X);
            TimeSpan time = (td2.Timestamp - td1.Timestamp);
            //To get velocity in m/s time.TotalSeconds
            double velocity = meters / time.TotalSeconds;
            return velocity;
        }
    }
}
