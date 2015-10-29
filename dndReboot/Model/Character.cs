using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data.Sql;
using System.ComponentModel;
using System.Collections.ObjectModel;
using dndReboot.Model.Classes;
using System.Reflection;
using System.Windows;
using dndReboot.DataAccess;
using dndReboot.Utilities;
using dndReboot.ViewModel;
using NotifyTest;

namespace dndReboot.Model
{
    public class Character : ModelBase
    {
        
        public static Character CreateNewCharacter()
        {
            return new Character();
        }
        public static Character CreateNewCharacter(string name, int xp, Alignment alignment, Ability strength, Ability dexterity, Ability constitution, Ability intelligence, Ability wisdom, Ability charisma, ObservableCollection<CharacterClass> classes)
        {
            return new Character
            {
                _name = name,
                _xp = xp,
                _alignment = alignment,
                _str = strength,
                _dex = dexterity,
                _con = constitution,
                _int = intelligence,
                _wis = wisdom,
                _chr = charisma,
                _classes = classes
            };
        }

        private string _playerName;
        public string PlayerName
        {
            get { return _playerName; }

            set
            {
                if (_playerName != value)
                {
                    _playerName = value;

                }
            }
        }

        #region Properties and Fields
        private int _maxhp;
        public int MaxHP
        {
            get
            {
                return _maxhp;
            }
            set
            {
                if (_maxhp != value)
                {
                    _maxhp = value;
                }
            }
        }

        private int _hp;
        public int HP
        {
            get
            {
                return _hp;
            }
            set
            {
                if (_hp != value)
                {
                    _hp = value;
                }
            }
        }

        private ObservableCollection<Feature> _features;
        public ObservableCollection<Feature> Features
        {
            get
            {
                return _features;
            }
            set
            {
                if (_features != value)
                {
                    _features = value;
                }
            }
        }

        //private ObservableCollection<Proficiency> _proficiencies;
        //public ObservableCollection<Proficiency> Proficiencies
        //{
        //    get
        //    {
        //        return _proficiencies;
        //    }
        //    set
        //    {
        //        if (_proficiencies != value)
        //        {
        //            _proficiencies = value;
        //        }
        //    }
        //}

        private ObservableCollection<CharacterClass> _classes;
        public ObservableCollection<CharacterClass> Classes
        {
            get
            {
                return _classes;
            }
            set
            {
                if (_classes != value)
                {
                    _classes = value;
                }
            }
        }

        private CharacterClass _class;
        public CharacterClass Class
        {
            get { return _class; }

            set
            {
                if (_class != value)
                {
                    _class = value;

                }
            }
        }

        private Alignment _alignment;
        public Alignment Alignment
        {
            get { return _alignment; }

            set
            {
                if (_alignment != value)
                {
                    _alignment = value;

                }
            }
        }

        private int _xp;
        public int XP
        {
            get
            {
                return _xp;
            }
            set
            {
                if (_xp != value)
                {
                    _xp = value;
                }
            }
        }

        private ObservableCollection<Ability> _abilities;
        public ObservableCollection<Ability> Abilities
        {
            get { return _abilities; }

            set
            {
                if (_abilities != value)
                {
                    _abilities = value;

                }
            }
        }

        private Race _race;
        public Race Race
        {
            get
            {
                return _race;
            }
            set
            {
                if (_race != value)
                {
                    _race = value;
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
                }
            }
        }

        private Background _background;
        public Background Background
        {
            get { return _background; }

            set
            {
                if (_background != value)
                {
                    _background = value;

                }
            }
        }

        private Ability _str;
        public Ability Str
        {
            get { return _str; }

            set
            {
                if (_str != value)
                {
                    _str = value;

                }
            }
        }

        private Ability _dex;
        public Ability Dex
        {
            get { return _dex; }

            set
            {
                if (_dex != value)
                {
                    _dex = value;

                }
            }
        }

        private Ability _con;
        public Ability Con
        {
            get { return _con; }

            set
            {
                if (_con != value)
                {
                    _con = value;

                }
            }
        }

        private Ability _int;
        public Ability Int
        {
            get { return _int; }

            set
            {
                if (_int != value)
                {
                    _int = value;

                }
            }
        }

        private Ability _wis;
        public Ability Wis
        {
            get { return _wis; }

            set
            {
                if (_wis != value)
                {
                    _wis = value;

                }
            }
        }

        private Ability _chr;
        public Ability Chr
        {
            get { return _chr; }

            set
            {
                if (_chr != value)
                {
                    _chr = value;

                }
            }
        }

        private int _characterLevel;
        public int CharacterLevel
        {
            get { return _characterLevel; }

            set
            {
                if (_characterLevel != value)
                {
                    _characterLevel = value;

                }
            }
        }

        #endregion

        public Character()
        {
            
            _name = "Sarah Brown";
            _classes = new ObservableCollection<CharacterClass> {new Bard(), new Barbarian()};
            XP = 6500;
            _background = Background.Sage;
            _playerName = "Meghan";
            _alignment = Alignment.LawfulGood;
            _class = new Bard();
            _str = new Ability("Strength") {Value = 15};
            _dex = new Ability("Dexterity") {Value = 14};
            _con = new Ability("Constitution") { Value = 13 };
            _int = new Ability("Intelligence") { Value = 12 };
            _wis = new Ability("Wisdom") { Value = 10 };
            _chr = new Ability("Charisma") { Value = 8 };

            Abilities = new ObservableCollection<Ability>
            {
                Str, Dex, Con, Int, Wis, Chr
            };
            
            //Race = Subraces.Human;
            Race = new Race
            {
                Name = "Human",
                RaceEnum = RaceEnum.Human,
                Darkvision = "No",
                Size = "Medium",
                Speed = 30
            };
        }



        public Character(string name)
        {
            _name = name;
            XP = 0;
            _str = new Ability("Strength");
            _dex = new Ability("Dexterity");
            _con = new Ability("Constitution");
            _int = new Ability("Intelligence");
            _wis = new Ability("Wisdom");
            _chr = new Ability("Charisma");

            Abilities = new ObservableCollection<Ability>
            {
                Str, Dex, Con, Int, Wis, Chr
            };
            
        }

        public void Bonus(Race race)
        {
            ObservableCollection<AbilityBonusViewModel> list = AbilityDBConverter.ConvertToVM(race.AbiBonus);
            foreach (AbilityBonusViewModel abvm in list)
            {
                if (abvm.SelectedAbility.Description == "Strength")
                {
                    Str.Value += abvm.SelectedBonus;
                }
                if (abvm.SelectedAbility.Description == "Dexterity")
                {
                    Dex.Value += abvm.SelectedBonus;
                }
                if (abvm.SelectedAbility.Description == "Constitution")
                {
                    Con.Value += abvm.SelectedBonus;
                }
                if (abvm.SelectedAbility.Description == "Intelligence")
                {
                    Int.Value += abvm.SelectedBonus;
                }
                if (abvm.SelectedAbility.Description == "Wisdom")
                {
                    Wis.Value += abvm.SelectedBonus;
                }
                if (abvm.SelectedAbility.Description == "Charisma")
                {
                    Chr.Value += abvm.SelectedBonus;
                }
                if (abvm.SelectedAbility.Description == "All")
                {
                    Str.Value += abvm.SelectedBonus;
                    Dex.Value += abvm.SelectedBonus;
                    Con.Value += abvm.SelectedBonus;
                    Int.Value += abvm.SelectedBonus;
                    Wis.Value += abvm.SelectedBonus;
                    Chr.Value += abvm.SelectedBonus;

                }
            }
        }

    }
}
