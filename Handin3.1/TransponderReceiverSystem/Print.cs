using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverSystem
{
    public class Print : IPrint
    {
        public void PrintTrack(TransponderObserverSoftware tr)
        {

            Console.WriteLine(tr.TrackObjectList); 
        }

        public void PrintTrackTrue(TrackOjects td)
        {
            Console.WriteLine(td._tag);
            Console.WriteLine(td._x_coordinate);
            Console.WriteLine(td._y_coordinate);
            Console.WriteLine(td._altitude);
            Console.WriteLine(td._timestamp);
        }
    }
}
