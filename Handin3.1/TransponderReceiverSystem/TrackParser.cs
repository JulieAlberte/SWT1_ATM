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
            //string[] data = new string[5];
            string[] separators = { ";" };
            string[] data = values.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(data[0]);
            Console.WriteLine(data[1]);
            Console.WriteLine(data[2]);
            Console.WriteLine(data[3]);
            Console.WriteLine(data[4]);
            return data;
        }
    }
}
