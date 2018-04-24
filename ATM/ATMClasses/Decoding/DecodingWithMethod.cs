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
            //Sletter tempTrackList
            tempTrackList.Clear();
            //Gemmer gammel data fra trackList i templist, til beregning af velocity og course
            tempTrackList = trackList.GetRange(0, trackList.Count);
            //Sletter trackList
            trackList.Clear();
           
            //Adds and converts new flight(s)
            foreach (var track in args.TransponderData)
            {
                //Converts into a trackobject 
                var td = Convert(track);
                //Validates if it's in our area
                if (TV.ValidateTrack(td.X, td.Y, td.Altitude))
                {
                    //Tjekker hele den gamle liste igennem, om der findes data om flyet, og derfor kan beregne velocity og course
                    for (int i = 0; i < tempTrackList.Count; i++)
                        {
                            //Tjekker på ens tags mellem gamle data og ny data
                            if (tempTrackList[i].Tag.Equals(td.Tag, StringComparison.OrdinalIgnoreCase))
                            {
                                //Beregner og sætter velocity og course
                                CalculateVelocity(tempTrackList[i], td);
                                CalculateCourse(tempTrackList[i], td);
                            }
                        }
                    //Tilføjer ny data til listen
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

        public void CalculateVelocity(TrackData oldTrackData, TrackData newTrackData)//, DateTime lastTime, DateTime currentTime)
        {
            //Finder afstanden mellem gamle og nye punkt
            double dist = Math.Sqrt(Math.Pow((newTrackData.X - oldTrackData.X), 2) + Math.Pow((newTrackData.Y - oldTrackData.Y), 2));
            
            //Tiden der er gået
            var time = newTrackData.Timestamp - oldTrackData.Timestamp;
            //Beregner Velocity
            var velocity = time.TotalSeconds == 0 ? 0 : Math.Round(dist / time.TotalSeconds);
            //Sætter velocity i objektet
            newTrackData.Velocity = velocity;
        }

        public void CalculateCourse(TrackData oldTrackData, TrackData newTrackData)
        {
            //Needs to added degrees "nord" or "south" and so on
            var angleDeg = Math.Atan2(-(newTrackData.Y - oldTrackData.Y), newTrackData.X - oldTrackData.X) * 180 / Math.PI;

            angleDeg += 90;

            if (angleDeg < 0)
                angleDeg += 360;

            newTrackData.Course = (int)angleDeg;
        }
    }
}
