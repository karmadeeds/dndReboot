using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dndReboot.Model;

namespace dndReboot.DataAccess
{
    public class RaceAddedEventArgs : EventArgs
    {
        public RaceAddedEventArgs(Race newRace)
        {
            this.NewRace = newRace;
        }
        public Race NewRace { get; private set; }
    }
}
