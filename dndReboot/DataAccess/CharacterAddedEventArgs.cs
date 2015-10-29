using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dndReboot.Model;

namespace dndReboot.DataAccess
{
    public class CharacterAddedEventArgs : EventArgs
    {
        public CharacterAddedEventArgs(Character newCharacter)
        {
            this.NewCharacter = newCharacter;
        }
        public Character NewCharacter { get; private set; }
    }
}
