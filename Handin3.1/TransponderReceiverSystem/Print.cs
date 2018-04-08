using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverSystem
{
    class Print : IPrint
    {
        public void PrintTrack(TransponderObserverSoftware tr)
        {
            Console.WriteLine(tr.TrackObjectList); 
        }
    }
}
