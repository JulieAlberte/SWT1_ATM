using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverSystem
{
    public interface ITransponderReceiver
    {
       event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;
 
    }
}
