using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Data;
using ATMClasses.Interfaces;
using TransponderReceiver;
using ATMClasses.Calculate;
using ATMClasses.Calculate.Interface;


namespace ATMClasses.Decoding
{
    public class DecodingWithMethod
    {
        private List<TrackData> _trackList;
        private ITrackReceiver _outputTrackReceiver;
        private List<TrackData> _tempTrackList;
        private ICalculateCourse _calculateCourse;
        private ICalculateVel _calculateVelocity;
        private TrackValidation _trackValidation;
        private Track _track;
        private TrackSeperation _trackSeperation;
        
        public DecodingWithMethod(ITransponderReceiver rawReceiver, ITrackReceiver trackReceiver)
        {
            //When data from flight bleeps in
            rawReceiver.TransponderDataReady += OnRawData;

            _trackList = new List<TrackData>();
            _outputTrackReceiver = trackReceiver;
            _tempTrackList = new List<TrackData>();
            _calculateCourse = new CalculateCourse();
            _calculateVelocity = new CalculateVelocity();
            _trackValidation = new TrackValidation();
            _track = new Track();
            _trackSeperation = new TrackSeperation();
        }

        public void OnRawData(object o, RawTransponderDataEventArgs args)
        {
            _tempTrackList.Clear();
            //Saves old data from _trackList into _tempTrackList
            _tempTrackList = _trackList.GetRange(0, _trackList.Count);
            _trackList.Clear();
           
            //Adds and converts new flight(s)
            foreach (var track in args.TransponderData)
            {
                var td = _track.Convert(track);
                
                //Validates if it's in our area
                if (_trackValidation.ValidateTrack(td.X, td.Y, td.Altitude))
                {
                    //Forloop to check if the old list, _tempTrackList, holds any data about the flight
                    for (int i = 0; i < _tempTrackList.Count; i++)
                        {
                            if (_tempTrackList[i].Tag.Equals(td.Tag, StringComparison.OrdinalIgnoreCase))
                            {
                                //If it holds any data about the flight, calculate veocity and course
                                _calculateVelocity.CalVelocity(_tempTrackList[i],td);
                                _calculateCourse.CalCourse(_tempTrackList[i],td);
                            }
                        }
                    //Adds flight to _trackList
                    _trackList.Add(td);
                }
            }

            _trackSeperation.CheckForSeperation(_trackList);
            //Prints all tracks in _trackList
            _outputTrackReceiver.ReceiveTracks(_trackList); 
        }
    }
}
