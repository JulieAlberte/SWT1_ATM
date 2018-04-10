using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverSystem.Classes
{
    public class Print : IPrint
    {
        public void PrintTrack(TransponderObserverSoftware tr)
        {

            Console.WriteLine(tr.TrackObjectList);
        }

        public void PrintTrackTrue(TrackOjects td)
        {
            Console.WriteLine($"Tag:            {td._tag}");
            Console.WriteLine($"X coordinate:   {td._x_coordinate} meters");
            Console.WriteLine($"Y coordinate:   {td._y_coordinate} meters");
            Console.WriteLine($"Altitude:       {td._altitude} meters");
            Console.WriteLine($"Timestamp:      {td._timestamp}");
            Console.WriteLine();
        }
    }
}

