using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using dndReboot.Utilities;

namespace dndReboot.Model.Classes
{
    public class Barbarian : CharacterClass
    {

        private List<Feature> _barbarianfeatures;
        public List<Feature> BarbarianFeatures
        {
            get
            {
                return _barbarianfeatures;
            }
            set
            {
                if (_barbarianfeatures != value)
                {
                    _barbarianfeatures = value;
                    ClearError("BarbarianFeatures");
                    OnPropertyChanged("BarbarianFeatures");
                }
            }
        }

        private int _ragedamage;
        public int RageDamage
        {
            get
            {
                return _ragedamage;
            }
            set
            {
                if (_ragedamage != value)
                {
                    _ragedamage = value;
                    ClearError("RageDamage");
                    OnPropertyChanged("RageDamage");
                }
            }
        }

        private int _rages;
        public int Rages
        {
            get
            {
                return _rages;
            }
            set
            {
                if (_rages != value)
                {
                    _rages = value;
                    ClearError("Rages");
                    OnPropertyChanged("Rages");
                }
            }
        }

        private PrimalPath _primalpath;
        public PrimalPath PrimalPath
        {
            get
            {
                return _primalpath;
            }
            set
            {
                if (_primalpath != value)
                {
                    _primalpath = value;
                    ClearError("PrimalPath");
                    OnPropertyChanged("PrimalPath");
                }
            }
        }

        public Barbarian()
        {
            Name = "Barbarian";
            HitDice = Dice.d12;
            Level = 3;
            Spellcaster = false;
            Ritualcaster = false;
            KnowSpells = false;
        }
    }
}
