using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverSystem
{

    class Program
    {
        static void Main(string[] args)
        {
            TransponderObserverSoftware tr = new TransponderObserverSoftware();
            tr.print();
        }
    }
}
