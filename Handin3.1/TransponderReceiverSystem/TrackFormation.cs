using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverSystem
{
    class TrackFormation : ITrackFormation
    {
        //private int year { set; get; }
        public string FormatTimestamp(string timestamp)
        {
            //Formatér timestamp, så det er "pænt", se opgavebeskrivelse
            //4 første tal skal være år, 2 næste er dato ..-... 
            //year= timestamp[4]
            return timestamp;
            //return year,date,month,....
        }
    }
}
