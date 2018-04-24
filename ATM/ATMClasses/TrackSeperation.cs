using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Data;
using ATMClasses.Interfaces;

namespace ATMClasses
{
    public class TrackSeperation : ITrackSeperation
    {
        private readonly SeperationEventData _seperationEvent = new SeperationEventData();
        private readonly List<SeperationEventData> _seperationEventsList = new List<SeperationEventData>();
        private readonly IFileLog _fileLog = new FileLog();

        

        //public TrackSeperation()
        //{
        //    _seperationEvent = new SeperationEventData();
        //    _seperationEventsList = new List<SeperationEventData>();
        //    _fileLog = new FileLog();
        //}

        public void CheckForSeperation(List<TrackData> trackDatalList)
        {
            for (var i = 0; i < trackDatalList.Count; i++)
            {
                for (int j = 0; j < trackDatalList.Count; j++)
                {
                    // If there is more then 2 trackobjects in list and the tracks tags not are the same
                    if (trackDatalList.Count >= 2 && trackDatalList[i].Tag != trackDatalList[j].Tag)
                    {
                        //Coordinates to the to tracks we are investegating 
                        double x1 = trackDatalList[i].X;
                        double x2 = trackDatalList[j].X;
                        double y1 = trackDatalList[i].Y;
                        double y2 = trackDatalList[j].Y;

                        //Horizontal seperation less than 5000 meters
                        //Formula: distance = sqrt((x1-x2)^2+(y1-y2)^2)
                        var horizontalDistance = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));

                        //vertical seperation less than 300 meters
                        var verticalDistance = Math.Abs(trackDatalList[i].Altitude - trackDatalList[j].Altitude);

                        if (horizontalDistance < 5000 && verticalDistance < 300)
                        {
                            var timeOfEvent = trackDatalList[i].Timestamp > trackDatalList[j].Timestamp
                                ? trackDatalList[i].Timestamp
                                : trackDatalList[j].Timestamp;

                            _seperationEvent.TAG1 = trackDatalList[i].Tag;
                            _seperationEvent.TAG2 = trackDatalList[i].Tag;
                            _seperationEvent.TimeOfEvent = timeOfEvent;

                            _seperationEventsList.Add(_seperationEvent);
                            _fileLog.LogToFile(_seperationEventsList);
                            Console.WriteLine("Warning!!");
                        }
                    }
                }
            }
        }
    }
}
