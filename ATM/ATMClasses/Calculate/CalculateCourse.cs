using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Calculate.Interface;
using ATMClasses.Data;

namespace ATMClasses.Calculate
{
    class CalculateCourse : ICalculateCourse
    {
        public void CalCourse(TrackData track1, TrackData track2)
        {
            double deltaX = track2.X - track1.X;
            double deltaY = track2.Y - track1.Y;

            double Degree = 0;

            if (deltaX == 0)
            {
                //if deltaY er større end 0
                // condition ? first_expression : second_expression;
                Degree = deltaY > 0 ? 0 : 180;
            }
            else
            {
                double radian = Math.Atan2(deltaY, deltaX);
                //Convert to degress 
                Degree = radian / Math.PI * 180;

                Degree = 90 - Degree;
                if (Degree < 0)
                {
                    Degree += 360;
                }
            }

            track2.Course = Degree;

        }


    }
}

//public void CalculateCourse(TrackData oldTrackData, TrackData newTrackData)
//{
//var angleDeg = Math.Atan2(-(newTrackData.Y - oldTrackData.Y), newTrackData.X - oldTrackData.X) * 180 / Math.PI;

//angleDeg += 90;

//if (angleDeg < 0)
//    angleDeg += 360;

//newTrackData.Course = (int)angleDeg;
//}
