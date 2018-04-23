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


            //int meters = (td2.X - td1.X);
            //bTimeSpan time = (td2.Timestamp - td1.Timestamp);
            //To get velocity in m/s time.TotalSeconds
            //double velocity = meters / time.TotalSeconds;
            //return velocity;
        }


        //public int CalculateCourse(TrackData td1, TrackData td2)
        //{
            //double angle = Math.Atan2(td1, td2) * (180 / Math.PI);
            //return () angle; 
            // det her virker slet ikke, så skal laves om

        //}
    }

    
}
