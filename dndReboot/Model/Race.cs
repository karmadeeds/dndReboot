using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data.Sql;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using dndReboot.Commands;
using dndReboot.Utilities;
using dndReboot.View;
using dndReboot.ViewModel;

namespace dndReboot.Model
{
    public class Race : ModelBase
    {

        public static Race CreateNewRace()
        {
            return new Race();
        }

        public string AbiBonus { get; set; }

        public ObservableCollection<string> ConvertedBonuses { get; set; }

        public ICommand Command { get; set; }

        public void CommandCommand(object obj)
        {
            CharacterCreationView cc = obj as CharacterCreationView;
            CharacterCreationViewModel ccvm = cc.DataContext as CharacterCreationViewModel;
            ccvm.SelectedRace = this;
        }

        public Race()
        {
            Name = "None";
            AbiBonus = "a+0";
            Size = "Tiny";
            Speed = 0;
            Darkvision = "None";
            WeaponProficiencies = new ObservableCollection<EnumBase>();
            ToolProficiencies = new ObservableCollection<EnumBase>();
            ArmorProficiencies = new ObservableCollection<EnumBase>();
            SkillProficiencies = new ObservableCollection<EnumBase>();
            Languages = new ObservableCollection<EnumBase>();
            RacialTraits = new ObservableCollection<Feature>();
            Command = new RelayCommand(CommandCommand);
        }

        void Race_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsC")   MessageBox.Show(Name);
        }


        private bool _isC;

        public bool IsC
        {
            get { return _isC; }

            set
            {
                if (_isC != value)
                {
                    _isC = value;
                    OnPropertyChanged("IsC");

                }
            }
        }


        private string _name;

        private string _size;
        private int _speed;
        private string _darkvision;
        private ObservableCollection<EnumBase> _weaponProficiencies;
        private ObservableCollection<EnumBase> _toolProficiencies;
        private ObservableCollection<EnumBase> _armorProficiencies;
        private ObservableCollection<EnumBase> _skillProficiencies;
        private ObservableCollection<EnumBase> _languages;
        private ObservableCollection<Feature> _racialTraits;


        private string _parentRace;

        public string ParentRace
        {
            get { return _parentRace; }

            set
            {
                if (_parentRace != value)
                {
                    _parentRace = value;
                    OnPropertyChanged("MainRace");

                }
            }
        }

        public bool IsSelected { get; set; }

        public bool EnableValidation { get; set; }
        
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
                    if (EnableValidation && string.IsNullOrEmpty(this.Name))
                        SetError("Name", "Name is Required");
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Size
        {
            get
            {
                return _size;
            }
            set
            {
                if (_size != value)
                {
                    _size = value;
                    ClearError("Size");
                    if (EnableValidation && string.IsNullOrEmpty(this.Name))
                        SetError("Size", "Size is Required");
                    OnPropertyChanged("Size");
                }
            }
        }
        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                if (_speed != value)
                {
                    _speed = value;
                    ClearError("Speed");
                    if (EnableValidation && string.IsNullOrEmpty(this.Name))
                        SetError("Speed", "Speed is Required");
                    OnPropertyChanged("Speed");
                }
            }
        }
        public string Darkvision
        {
            get
            {
                return _darkvision;
            }
            set
            {
                if (_darkvision != value)
                {
                    _darkvision = value;
                    ClearError("Darkvision");
                    if (EnableValidation && string.IsNullOrEmpty(this.Name))
                        SetError("Darkvision", "Darkvision is Required");
                    OnPropertyChanged("Darkvision");
                }
            }
        }

        public ObservableCollection<EnumBase> WeaponProficiencies
        {
            get
            {
                return _weaponProficiencies;
                
            }
            set
            {
                if (_weaponProficiencies != value)
                {
                    _weaponProficiencies = value;
                    OnPropertyChanged("WeaponProficiencies");
                }
            }
        }
        public ObservableCollection<EnumBase> ArmorProficiencies
        {
            get
            {
                return _armorProficiencies;

            }
            set
            {
                if (_armorProficiencies != value)
                {
                    _armorProficiencies = value;
                    OnPropertyChanged("ArmorProficiencies");
                }
            }
        }
        public ObservableCollection<EnumBase> ToolProficiencies
        {
            get
            {
                return _toolProficiencies;

            }
            set
            {
                if (_toolProficiencies != value)
                {
                    _toolProficiencies = value;
                    OnPropertyChanged("ToolProficiencies");
                }
            }
        }
        public ObservableCollection<EnumBase> Languages
        {
            get
            {
                return _languages;
            }
            set
            {
                if (_languages != value)
                {
                    _languages = value;
                    ClearError("Languages");
                    OnPropertyChanged("Languages");
                }
            }
        }
        public ObservableCollection<Feature> RacialTraits
        {
            get
            {
                return _racialTraits;
            }
            set
            {
                if (_racialTraits != value)
                {
                    _racialTraits = value;
                    ClearError("RacialTraits");
                    OnPropertyChanged("RacialTraits");
                }
            }
        }
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

        private RaceEnum _raceEnum;

        public RaceEnum RaceEnum
        {
            get { return _raceEnum; }

            set
            {
                if (_raceEnum != value)
                {
                    _raceEnum = value;
                    OnPropertyChanged("RaceEnum");

                }
            }
        }

    }
}
