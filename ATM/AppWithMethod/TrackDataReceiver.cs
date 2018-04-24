using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ATMClasses.Data;
using ATMClasses.Interfaces;

namespace AppWithMethod
{
    class TrackDataReceiver : ITrackReceiver
    {
<<<<<<< HEAD
        //Calculator vc = new Calculator();
=======
>>>>>>> 494b52499c30117af52eb0d87982196808352da4
        public void ReceiveTracks(List<TrackData> tracks)
        {
            //Thread.Sleep(2000);
            System.Console.Clear();
            foreach (var track in tracks)
            {
                System.Console.WriteLine(track);
            }
        }
    }
}
