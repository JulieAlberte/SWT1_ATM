using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses.Interfaces
{
    interface ISeperationEventController
    {
        void CoflictDetected(List<SeperationEvent> newSeperationsEvent);

    }
}
