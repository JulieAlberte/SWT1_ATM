﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace TransponderReceiverSystem
{
    public class TransponderObserverSoftware
    {
        public TransponderObserverSoftware()
        {
            var transponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            transponderReceiver.TransponderDataReady+= TransponderReceiverOnTransponderDataReady;
        }

        private void TransponderReceiverOnTransponderDataReady(object sender,
            RawTransponderDataEventArgs rawTransponderDataEventArgs)
        {
            List<string> values = rawTransponderDataEventArgs.TransponderData;
            CreateTrackObject(values);
        }

        public void CreateTrackObject(List<string> values)
        {
            TrackValidation myTackTrackValidation = new TrackValidation();

            string[] data = {};

            foreach (string value in values)
            {
                data = TrackParser.ParseString(value);
                if (myTackTrackValidation.ValidateTrack(data[1], data[2], data[3]))
                {
                    TrackOjects td = new TrackOjects(data[0], data[1], data[2], data[3], data[4]);
                }
                else
                {
                    Console.WriteLine("Not in area");
                }
            }
        }
    }
}
