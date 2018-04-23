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



            Console.ReadKey();
        }
    }
}
