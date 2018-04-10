using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TransponderReceiverSystem.Classes
{
    public enum Months
    {
        January = 01,
        February = 02,
        March = 03,
        April = 04,
        May = 05,
        June = 06,
        July = 07,
        August = 08,
        September = 09,
        October = 10,
        November = 11,
        December = 12
    }
    public class TrackFormation : ITrackFormation
    {
        //private int year { set; get; }
        public string FormatTimestamp(string timestamp)
        {
            //Formatér timestamp, så det er "pænt", se opgavebeskrivelse
            //4 første tal skal være år, 2 næste er dato ..-... 
            // Fx bliver 20151006213456789 til: October 6th, 2015, at 21:34:56 and 789 milliseconds

            var year = timestamp.Substring(0, 4);
            var month = timestamp.Substring(4, 2);
            var day = timestamp.Substring(6, 2);
            var hour = timestamp.Substring(8, 2);
            var minute = timestamp.Substring(10, 2);
            var second = timestamp.Substring(12, 2);
            var millisecond = timestamp.Substring(14, 3);

            // Dag skal ikke udskrives med 0
            if (timestamp.Substring(6, 1).Contains("0"))
            {
                day = timestamp.Substring(7, 1);
            }

            Months formattedMonth = (Months)Enum.Parse(typeof(Months), month);

            switch (timestamp.Substring(7, 1))
            {
                //First day in month -> add st to day
                case "1":
                    if (timestamp.Substring(7, 1).Contains("0") && timestamp.Substring(6, 1).Contains("1"))
                    {
                        day = day + "st";
                        //break;
                    }

                    //day = day + "st";
                    break;
                // Second day in mount -> add "nd" to day
                case "2":
                    if (timestamp.Substring(7, 1).Contains("0") && timestamp.Substring(6, 1).Contains("2"))
                    {
                        day = day + "nd";
                        //break;
                    }
                    break;
                //Third day in mount --> add "rd" to day  
                case "3":
                    if (timestamp.Substring(7, 1).Contains("0") && timestamp.Substring(6, 1).Contains("3"))
                    {
                        day = day + "rd";
                    }
                    break;
                // All other days add "th" to day
                default:
                    day = day + "th";
                    break;


            }
            // Fx bliver 20151006213456789 til: October 6th, 2015, at 21:34:56 and 789 milliseconds
            string output = formattedMonth + " " + day + ", " + year + ", at " + hour + ":" + minute + ":" + second +
                            " and " + millisecond + " milliseconds";
            return output;
            //return year,date,month,....
        }

    }
}
