using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Calculate.Interface;
using ATMClasses.Data;

namespace ATMClasses.Calculate
{
    public class CalculateVelocity : ICalculateVel
    {
        private double x1 { get; set; }
        private double x2 { get; set; }
        private double y1 { get; set; }
        private double y2 { get; set; }

        public void CalVelocity(TrackData track1, TrackData track2)
        {
            //Coordinates 
            x1 = track1.X;
            x2 = track2.X;
            y1 = track1.Y;
            y2 = track2.Y;

            //Distance between the 2 tracks
            double distance = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));

            double time = track2.Timestamp.Subtract(track1.Timestamp).TotalSeconds;

            track2.Velocity = distance / time;
        }

    }
}
