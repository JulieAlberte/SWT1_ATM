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
