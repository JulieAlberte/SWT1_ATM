using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace TransponderReceiverSystem.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var transponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            TransponderObserverSoftware tr = new TransponderObserverSoftware(transponderReceiver);
            Console.ReadKey();
        }
    }
}
