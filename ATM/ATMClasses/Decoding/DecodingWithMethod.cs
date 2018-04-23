using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Data;
using ATMClasses.Interfaces;
using TransponderReceiver;


namespace ATMClasses.Decoding
{
    public class DecodingWithMethod
    {
        private List<TrackData> trackList;
        private ITrackReceiver outputTrackReceiver;
        private List<TrackData> tempTrackList;

        public DecodingWithMethod(ITransponderReceiver rawReceiver, ITrackReceiver trackReceiver)
        {
            rawReceiver.TransponderDataReady += OnRawData;

            outputTrackReceiver = trackReceiver;

            trackList = new List<TrackData>();
            tempTrackList = new List<TrackData>();
        }

        public void OnRawData(object o, RawTransponderDataEventArgs args)
        {
            TrackValidation TV = new TrackValidation();
            tempTrackList.Clear();
            tempTrackList = trackList;
            trackList.Clear();

            //Adds and converts new flight(s)
            foreach (var track in args.TransponderData)
            {
                //Converts into a trackobject 
                var td = Convert(track);
                //Validates if it's in our area
                if (TV.ValidateTrack(td.X, td.Y, td.Altitude))
                {
                    if (tempTrackList.Count != 0)
                    {
                        for (int i = 0; i < tempTrackList.Count; i++)
                        {
                            if (tempTrackList[i].Tag.Equals(td.Tag, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("Jeg er her");
                                td.Velocity = CalculateVelocity(tempTrackList[i], td);
                                CalculateCourse(tempTrackList[i], td);
                            }
                        }
                    }

                    trackList.Add(td);
                }
            }
            
            //printer all tracks i listen
            outputTrackReceiver.ReceiveTracks(trackList); 
        }

        private TrackData Convert(string data)
        {
            TrackData track = new TrackData();
            var words = data.Split(';');
            track.Tag = words[0];
            track.X = int.Parse(words[1]);
            track.Y = int.Parse(words[2]);
            track.Altitude = int.Parse(words[3]);
            track.Timestamp = DateTime.ParseExact(words[4], "yyyyMMddHHmmssfff",
                System.Globalization.CultureInfo.InvariantCulture);
            track.Course = 0;
            track.Velocity = 0;

            return track;
        }

        public double CalculateVelocity(TrackData oldTrackData, TrackData newTrackData)//, DateTime lastTime, DateTime currentTime)
        {
            double dist = Math.Sqrt(Math.Pow((oldTrackData.X - newTrackData.X), 2) + Math.Pow((oldTrackData.Y - newTrackData.Y), 2));


            //var dist = (newTrackData.Course - oldTrackData.Course);
            var time = newTrackData.Timestamp - oldTrackData.Timestamp;
            //var time = currentTime - lastTime;
            //var velocity = time.TotalSeconds == 0 ? 0 : Math.Round(dist / time.TotalSeconds);
            //newTrackData.Velocity = velocity;
            //td2.Velocity = velocity;
            return time.TotalSeconds == 0 ? 0 : Math.Round(dist / time.TotalSeconds);
        }

        public void CalculateCourse(TrackData oldTrackData, TrackData newTrackData)
        {
            var angleDeg = Math.Atan2(-(newTrackData.Y - oldTrackData.Y), newTrackData.X - oldTrackData.X) * 180 / Math.PI;

            angleDeg += 90;

            if (angleDeg < 0)
                angleDeg += 360;

            newTrackData.Course = (int)angleDeg;
            //return (int)angleDeg;
        }
    }
}
