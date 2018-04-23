using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Data;
using ATMClasses.Interfaces;

namespace AppWithMethod
{
    class TrackDataReceiver : ITrackReceiver
    {
        Calculator vc = new Calculator();
        public void ReceiveTracks(List<TrackData> tracks)
        {
            foreach (var track in tracks)
            {
                System.Console.WriteLine(track);
            }
        }
    }
}
