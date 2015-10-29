using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dndReboot.Model;
using dndReboot.Utilities;

namespace dndReboot.ViewModel
{
    public class RaceViewModel : ViewModelBase
    {

        private string _name;
        private int _speed;
        private Size _size;
        private string _darkvision;
        private ObservableCollection<AbilityBonusViewModel> _abilityBonuses;
        private ObservableCollection<EnumBase> _weaponProficiencies;
        private ObservableCollection<EnumBase> _armorProficiencies;
        private ObservableCollection<EnumBase> _toolProficiencies;
        private ObservableCollection<EnumBase> _languageProficiencies;
        private ObservableCollection<EnumBase> _skillProficiencies;

        public ObservableCollection<EnumBase> SkillProficiencies
        {
            get { return _skillProficiencies; }

            set
            {
                if (_skillProficiencies != value)
                {
                    _skillProficiencies = value;
                    OnPropertyChanged("SkillProficiencies");

                }
            }
        }
        public ObservableCollection<EnumBase> LanguageProficiencies
        {
            get { return _languageProficiencies; }

            set
            {
                if (_languageProficiencies != value)
                {
                    _languageProficiencies = value;
                    OnPropertyChanged("LanguageProficiencies");

                }
            }
        }
        public ObservableCollection<EnumBase> ToolProficiencies
        {
            get { return _toolProficiencies; }

            set
            {
                if (_toolProficiencies != value)
                {
                    _toolProficiencies = value;
                    OnPropertyChanged("ToolProficiencies");

                }
            }
        }
        public ObservableCollection<EnumBase> ArmorProficiencies
        {
            get { return _armorProficiencies; }

            set
            {
                if (_armorProficiencies != value)
                {
                    _armorProficiencies = value;
                    OnPropertyChanged("ArmorProficiencies");

                }
            }
        }
        public ObservableCollection<EnumBase> WeaponProficiencies
        {
            get { return _weaponProficiencies; }

            set
            {
                if (_weaponProficiencies != value)
                {
                    _weaponProficiencies = value;
                    OnPropertyChanged("WeaponProficiencies");

                }
            }
        }
        public ObservableCollection<AbilityBonusViewModel> AbilityBonuses
        {
            get { return _abilityBonuses; }

            set
            {
                if (_abilityBonuses != value)
                {
                    _abilityBonuses = value;
                    OnPropertyChanged("AbilityBonuses");

                }
            }
        }
        public string Darkvision
        {
            get { return _darkvision; }

            set
            {
                if (_darkvision != value)
                {
                    _darkvision = value;
                    OnPropertyChanged("Darkvision");

                }
            }
        }
        public Size Size
        {
            get { return _size; }

            set
            {
                if (_size != value)
                {
                    _size = value;
                    OnPropertyChanged("Size");

                }
            }
        }
        public int Speed
        {
            get { return _speed; }

            set
            {
                if (_speed != value)
                {
                    _speed = value;
                    OnPropertyChanged("Speed");

                }
            }
        }
        public string Name
        {
            get { return _name; }

            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");

                }
            }
        }

    }
}
