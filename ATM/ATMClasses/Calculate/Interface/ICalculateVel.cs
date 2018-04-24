using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Data;
namespace ATMClasses.Calculate.Interface
{
   public interface ICalculateVel
   {
      void CalVelocity(TrackData track1, TrackData track2);
   }
}
