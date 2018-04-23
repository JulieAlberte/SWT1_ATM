using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Data;

namespace AppWithMethod
{
    public class Calculator
    {
        public double CalculateVelocity(TrackData td1, TrackData td2, DateTime lastTime, DateTime currentTime)
        {
            var dist = (td2.X - td1.X); 
            var time = currentTime - lastTime;
            return time.TotalSeconds == 0 ? 0 : Math.Round(dist / time.TotalSeconds);
        }


        public int CalculateCourse(TrackData td1, TrackData td2)
        {
        var angleDeg = Math.Atan2(-(td2.Y- td1.Y), td2.X - td1.X) * 180 / Math.PI;

        angleDeg += 90;

        if (angleDeg< 0)
            angleDeg += 360;

        return (int) angleDeg;
        }
    }


}
