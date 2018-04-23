using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;
using TransponderReceiverSystem.Classes;

namespace TransponderReceiverSystem.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            ITransponderReceiver transponderDataReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();

            var decoder = new TransponderObserverSoftware(transponderDataReceiver);
        
            //decoder.TrackObjectList
            foreach (var track in decoder.TrackObjectList)
            {
                PrintTrackTrue(track);
            }

            Console.ReadKey();
        }


        private static void PrintTrackTrue(TrackOjects td)
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
