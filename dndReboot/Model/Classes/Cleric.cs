using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dndReboot.Utilities;

namespace dndReboot.Model.Classes
{
    public class Cleric : CharacterClass
    {
        private Domain _domain;
        public Domain Domain
        {
            get { return _domain; }

            set
            {
                if (_domain != value)
                {
                    _domain = value;
                    OnPropertyChanged("Domain");

                }
            }
        }

        public Cleric()
        {
            Name = "Cleric";
            HitDice = Dice.d8;
            Spellcaster = true;
            Ritualcaster = true;
        }
    }
}
