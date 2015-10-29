using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using dndReboot.Utilities;

namespace dndReboot.Model
{
    public abstract class CharacterClass : ModelBase
    {
        private ObservableCollection<Feature> _features;
        public ObservableCollection<Feature> Features
        {
            get { return _features; }

            set
            {
                if (_features != value)
                {
                    _features = value;
                    OnPropertyChanged("Features");

                }
            }
        }
 
        private int _level;
        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                if (_level != value)
                {
                    _level = value;
                    ClearError("Level");
                    OnPropertyChanged("Level");
                }
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    ClearError("Name");
                    OnPropertyChanged("Name");
                }
            }
        }

        private Dice _hitdice;
        public Dice HitDice
        {
            get
            {
                return _hitdice;
            }
            set
            {
                if (_hitdice != value)
                {
                    _hitdice = value;
                    ClearError("HitDice");
                    OnPropertyChanged("HitDice");
                }
            }
        }

        private Archetype _archetype;
        public Archetype Archetype
        {
            get
            {
                return _archetype;
            }
            set
            {
                if (_archetype != value)
                {
                    _archetype = value;
                    ClearError("Archetype");
                    OnPropertyChanged("Archetype");
                }
            }
        }

        private bool _spellcaster;
        public bool Spellcaster
        {
            get
            {
                return _spellcaster;
            }
            set
            {
                if (_spellcaster != value)
                {
                    _spellcaster = value;
                    ClearError("Spellcaster");
                    OnPropertyChanged("Spellcaster");
                }
            }
        }

        private bool _ritualcaster;
        public bool Ritualcaster
        {
            get
            {
                return _ritualcaster;
            }
            set
            {
                if (_ritualcaster != value)
                {
                    _ritualcaster = value;
                    ClearError("Ritualcaster");
                    OnPropertyChanged("Ritualcaster");
                }
            }
        }

        private bool _knowspells;
        public bool KnowSpells
        {
            get
            {
                return _knowspells;
            }
            set
            {
                if (_knowspells != value)
                {
                    _knowspells = value;
                    ClearError("KnowSpells");
                    OnPropertyChanged("KnowSpells");
                }
            }
        }

        private int _cantrips;
        public int Cantrips
        {
            get
            {
                return _cantrips;
            }
            set
            {
                if (_cantrips != value)
                {
                    _cantrips = value;
                    ClearError("Cantrips");
                    OnPropertyChanged("Cantrips");
                }
            }
        }

        private int _spells;
        public int Spells
        {
            get
            {
                return _spells;
            }
            set
            {
                if (_spells != value)
                {
                    _spells = value;
                    ClearError("Spells");
                    OnPropertyChanged("Spells");
                }
            }
        }

        private int _spellsavedc;
        public virtual int Spellsavedc
        {
            get { return _spellsavedc; }

            set
            {
                if (_spellsavedc != value)
                {
                    _spellsavedc = value;
                    OnPropertyChanged("Spellsavedc");

                }
            }
        }

        private int _spellattackmodifier;
        public virtual int Spellattackmodifier
        {
            get { return _spellattackmodifier; }

            set
            {
                if (_spellattackmodifier != value)
                {
                    _spellattackmodifier = value;
                    OnPropertyChanged("Spellattackmodifier");

                }
            }
        }

        private int _cantripsknown;
        public int Cantripsknown
        {
            get { return _cantripsknown; }

            set
            {
                if (_cantripsknown != value)
                {
                    _cantripsknown = value;
                    OnPropertyChanged("Cantripsknown");

                }
            }
        }

        private int _highestSpellKnown;
        public int HighestSpellKnown
        {
            get { return _highestSpellKnown; }

            set
            {
                if (_highestSpellKnown != value)
                {
                    _highestSpellKnown = value;
                    OnPropertyChanged("HighestSpellKnown");

                }
            }
        }



    }
}
