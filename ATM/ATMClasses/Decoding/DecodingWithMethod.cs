using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Data;
using ATMClasses.Interfaces;
using TransponderReceiver;
using ATMClasses.Calculate;


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
                                CalculateVelocity calculateVelocity = new CalculateVelocity();
                                CalculateCourse calculateCourse = new CalculateCourse();
                                
                                calculateVelocity.CalVelocity(tempTrackList[i],td);
                                calculateCourse.CalCourse(tempTrackList[i],td);

                                //CalculateVelocity(tempTrackList[i], td);
                                //CalculateCourse(tempTrackList[i], td);
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



    }
}
