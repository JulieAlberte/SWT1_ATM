using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverSystem
{
    public class TrackOjects
    {
        public string _tag { get; private set; }
        public string _x_coordinate { get; private set; }
        public string _y_coordinate { get; private set; }
        public string _altitude { get;  private set; }
        public string _timestamp { get; private set; }
        public TrackOjects(string tag, string x_coordinate, string y_coordinate, string altitude, string timestamp)
        {
            _tag = tag;
            _x_coordinate = x_coordinate;
            _y_coordinate = y_coordinate;
            _altitude = altitude;
            _timestamp = timestamp;
        }
    }
}
