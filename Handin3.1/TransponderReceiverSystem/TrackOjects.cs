using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverSystem
{
    public class TrackOjects
    {
        private string _tag { get; set; }
        private string _x_coordinate { get; set; }
        private string _y_coordinate { get; set; }
        private string _altitude { get; set; }
        private string _timestamp { get; set; }
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
