using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace TransponderReceiverSystem
{

    class Program
    {
        static void Main(string[] args)
        {
            TransponderObserverSoftware tr = new TransponderObserverSoftware();
            Print myprinter = new Print();
            myprinter.PrintTrack(tr);

            Console.ReadKey();
        }
    }
}
