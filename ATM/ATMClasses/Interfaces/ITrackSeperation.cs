﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Data;

namespace ATMClasses.Interfaces
{
    public interface ITrackSeperation
    {
        void CheckForSeperation(List<TrackData> trackDatalList);
    }
}
