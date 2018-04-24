using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Calculate.Interface;
using ATMClasses.Data;

namespace ATMClasses.Calculate
{
    class CalculateVelocity : ICalculateVel
    {
        public void CalVelocity(TrackData track1, TrackData track2)
        {
            //Coordinates 
            double x1 = track1.X;
            double x2 = track2.X;
            double y1 = track1.Y;
            double y2 = track2.Y;

            //Distance between the 2 tracks
            double distance = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));

            double time = track2.Timestamp.Subtract(track1.Timestamp).TotalSeconds;

            track2.Velocity = distance / time;
        }

    }
    //public void CalVelocity(TrackData oldTrackData, TrackData newTrackDat)
    //{
    //    //Finder afstanden mellem gamle og nye punkt
    //    double dist = Math.Sqrt(Math.Pow((newTrackData.X - oldTrackData.X), 2) + Math.Pow((newTrackData.Y - oldTrackData.Y), 2));

    //    //Tiden der er gået
    //    var time = newTrackData.Timestamp - oldTrackData.Timestamp;
    //    //Beregner Velocity
    //    var velocity = time.TotalSeconds == 0 ? 0 : Math.Round(dist / time.TotalSeconds);
    //    //Sætter velocity i objektet
    //    newTrackData.Velocity = velocity;
    //}
}
