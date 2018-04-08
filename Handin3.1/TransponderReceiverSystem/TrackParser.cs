using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverSystem
{
    public class TrackParser
    {
        public static string[] ParseString(string values)
        {
            string[] separators = { ";" };
            string[] data = values.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return data;
        }
    }
}
