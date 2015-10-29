using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interactivity;
using dndReboot.Commands;
using dndReboot.DataAccess;
using dndReboot.Model;
using dndReboot.Properties;
using dndReboot.Utilities;
using Size = dndReboot.Utilities.Size;
using dndReboot.View;


namespace dndReboot.ViewModel
{
    public class RaceCreationViewModel : ViewModelBase
    {


        public string PageName {get { return "Race Creation"; }
        }
        //TEST STUFF 
        //WORKING THINGS NEED TO BE MOVED AFTER TESTING
        private bool _subraceChecked;

        public bool SubraceChecked
        {
            get { return _subraceChecked; }

            set
            {
                if (_subraceChecked != value)
                {
                    _subraceChecked = value;
                    OnPropertyChanged("SubraceChecked");

                }
            }
        }



        public ICommand AddAbilityBonusCommand { get; set; }
        public ICommand TestCommand { get; set; }
        private void AddAbility(StackPanel panel)
        {
            AbilityBonusViewModel newVM = new AbilityBonusViewModel(2,-1);
            AbilityBonusViewModelList.Add(newVM);
            //MessageBox.Show(AbilityBonus);
            var children = panel.Children;
            //children.Add(new AbilityBonusView(newVM));

            var eButton = children.OfType<Button>().First();
            children.Remove(eButton);
            children.Add(eButton);
        }
        public void Test(object obj)
        {
            string s = AbilityDBConverter.ConvertToDB(AbilityBonusViewModelList);

            MessageBox.Show(s);
            //ItemsControl ic = obj as ItemsControl;
            //string s = String.Empty;
            //foreach (AbilityBonusViewModel foo in ic.Items)
            //{
            //    bool bn = foo.SelectedAbility != null;
            //    if (bn == true)
            //    {
            //        MessageBox.Show(foo.SelectedAbility.Description + " " + foo.SelectedBonus);

            //    }
            //MessageBox.Show(bn + " "+nf);
            //}

            //MessageBox.Show(s);


        }

        public void AssignAbilityBonus(Race PR)
        {
            //MessageBox.Show(PR.AbiBonus);
            if (AbilityBonusViewModelList.Count > 0) AbilityBonusViewModelList.Clear();
            AbilityBonusViewModel abvm = DBConverter.ConvertToAbilityBonusView(PR.AbiBonus);
            AbilityBonusViewModelList.Add(abvm);
        }

        private string dbAbility(string s)
        {
            switch (s)
            {
                case "Strength":
                    return "s";
                    break;
                case "Dexterity":
                    return "d";
                    break;
                case "Constitution":
                    return "c";
                    break;
                case "Intelligence":
                    return "i";
                    break;
                case "Wisdom":
                    return "w";
                    break;
                case "Charisma":
                    return "h";
                    break;
                default:
                    return "";
            }
        }



        //Backing Fields

        private Race PR = new Race();
        private ICommand _addToolProficiencyCommand;
        private bool canExecute = true;
        private string _name;
        private string _abilityBonus;
        private Size _size;
        private int _speed;
        private string _darkvision;
        private string _parentRace;
        private Race _selectedParentRace = new Race();
        public Race SelectedParentRace
        {
            get { return _selectedParentRace; }

            set
            {
                if (_selectedParentRace != value)
                {
                    _selectedParentRace = value;
                    OnPropertyChanged("SelectedParentRace");

                }
            }
        }

        #region Collections

        private ObservableCollection<AbilityBonusViewModel> _abilityBonusViewModelList
            = new ObservableCollection<AbilityBonusViewModel>();
        public ObservableCollection<AbilityBonusViewModel> AbilityBonusViewModelList
        {
            get { return _abilityBonusViewModelList; }

            set
            {
                if (_abilityBonusViewModelList != value)
                {
                    _abilityBonusViewModelList = value;
                    OnPropertyChanged("AbilityBonusViewModelList");

                }
            }
        }

        private ObservableCollection<EnumBase> _selectedWeaponProficiencies = new ObservableCollection<EnumBase>();
        private ObservableCollection<EnumBase> _selectedArmorProficiencies = new ObservableCollection<EnumBase>();
        private ObservableCollection<EnumBase> _selectedToolProficiencies = new ObservableCollection<EnumBase>();
        private ObservableCollection<EnumBase> _selectedLanguageProficiencies = new ObservableCollection<EnumBase>();
        private ObservableCollection<EnumBase> _selectedSkillProficiencies = new ObservableCollection<EnumBase>();
        private ObservableCollection<EnumBase> _sizeList = new ObservableCollection<EnumBase>(EnumHelper.GetAllEnumsOfType<Size>());
        public ObservableCollection<EnumBase> AbilityList
        {
            get { return new ObservableCollection<EnumBase>(EnumHelper.GetAllEnumsOfType<AbilityEnums>()); }
        }
        private ObservableCollection<string> _darkvisionList = new ObservableCollection<string>
        {
            "No", 
            "30 ft",
            "60 ft",
            "120 ft",
        };

        private ObservableCollection<int> _speedList = new ObservableCollection<int>
        {
            5,
            10,
            15,
            20,
            25,
            30,
            35,
            40,
            45,
        }; 
        #endregion


        //COMMANDS
        private ICommand _parentSelectedCommand;
        public ICommand ParentSelectedCommand
        {
            get { return _parentSelectedCommand; }

            set
            {
                if (_parentSelectedCommand != value)
                {
                    _parentSelectedCommand = value;
                    OnPropertyChanged("ParentSelectedCommand");

                }
            }
        }
        private ICommand _selectLanguageCommand;
        public ICommand SelectLanguageCommand
        {
            get { return _selectLanguageCommand; }

            set
            {
                if (_selectLanguageCommand != value)
                {
                    _selectLanguageCommand = value;
                    OnPropertyChanged("SelectLanguageCommand");

                }
            }
        }
        public ICommand AddToolProficiencyCommand
        {
            get { return _addToolProficiencyCommand; }

            set
            {
                if (_addToolProficiencyCommand != value)
                {
                    _addToolProficiencyCommand = value;
                    OnPropertyChanged("AddToolProficiencyCommand");

                }
            }
        }
        private ICommand _parentToggledCommand;
        public ICommand ParentToggledCommand
        {
            get { return _parentToggledCommand; }

            set
            {
                if (_parentToggledCommand != value)
                {
                    _parentToggledCommand = value;
                    OnPropertyChanged("ParentToggledCommand");

                }
            }
        }
        public ICommand AddWeaponProficiencyCommand { get; set; }
        public ICommand AddArmorProficiencyCommand { get; set; }
        public ICommand AddSkillProficiencyCommand { get; set; }
        public ICommand AddLanguagesProficiencyCommand { get; set; }
        public ICommand CreateRaceCommand { get; set; }
        public ICommand ResetAllCommand { get; set; }


        private LanguageProficiencyViewModel _languageProficiencyViewModel;
        public LanguageProficiencyViewModel LanguageProficiencyViewModel
        {
            get { return _languageProficiencyViewModel; }

            set
            {
                if (_languageProficiencyViewModel != value)
                {
                    _languageProficiencyViewModel = value;
                    OnPropertyChanged("LanguageProficiencyViewModel");

                }
            }
        }
        private SkillProficiencyViewModel _skillProficiencyViewModel;
        public SkillProficiencyViewModel SkillProficiencyViewModel
        {
            get { return _skillProficiencyViewModel; }

            set
            {
                if (_skillProficiencyViewModel != value)
                {
                    _skillProficiencyViewModel = value;
                    OnPropertyChanged("SkillProficiencyViewModel");

                }
            }
        }


        //Constuctor

        public RaceCreationViewModel()
        {
            
            //Test Things
            AddAbilityBonusCommand = new TypeCommand<StackPanel>(AddAbility);
            TestCommand = new RelayCommand(Test, param =>canExecute);
            //Commands
            CreateRaceCommand = new RelayCommand(AddRaceToDB, param =>canExecute);
            AddArmorProficiencyCommand = new RelayCommand(AddArmorProficiencies, param=>canExecute);
            AddWeaponProficiencyCommand = new RelayCommand(AddWeaponProficiencies, param=>canExecute);
            AddToolProficiencyCommand = new RelayCommand(AddToolProficiencies, param=>canExecute);
            AddSkillProficiencyCommand = new RelayCommand(AddSkillProficiencies, param => canExecute);
            AddLanguagesProficiencyCommand = new RelayCommand(AddLanguageProficiencies, param => canExecute);
            ResetAllCommand = new RelayCommand(ResetAll);
            ParentSelectedCommand = new RelayCommand(ParentSelected, param => canExecute);
            ParentToggledCommand = new RelayCommand(ParentToggled, param => canExecute);

            //ViewModels
            WeaponProficiencyViewModel = new WeaponProficiencyViewModel(SelectedWeaponProficiencies);
            ArmorProficiencyViewModel = new ArmorProficiencyViewModel(SelectedArmorProficiencies);
            ToolProficiencyViewModel = new ToolProficiencyViewModel(SelectedToolProficiencies);
            SkillProficiencyViewModel = new SkillProficiencyViewModel(SelectedSkillProficiencies);
            LanguageProficiencyViewModel = new LanguageProficiencyViewModel(SelectedLanguageProficiencies);

            CurrentVM = WeaponProficiencyViewModel;
            PropertyChanged += SelectedParentRace_PropertyChanged;
        }



        //Command Methods Executed
        public void ParentToggled(object obj)
        {
            CheckBox cb = obj as CheckBox;
            if (cb.IsChecked == false)
            {
                if (PR != null)
                {
                    Speed = SpeedList[0];
                    Size = Size.Tiny;
                    Darkvision = DarkvisionList[0];
                    SelectedParentRace = ParentRaceList[0];
                }
            }
        }
        public void ParentSelected(object obj)
        {
            
            PR = obj as Race;
            if (PR != ParentRaceList[0])
            {
                SelectedParentRace = PR;
                Speed = PR.Speed;
                Size = Utility.ParseEnum<Size>(PR.Size);
                Darkvision = PR.Darkvision;
                AssignAbilityBonus(PR);
                //MessageBox.Show(PR.AbiBonus);


                SelectedWeaponProficiencies = PR.WeaponProficiencies;
                WeaponProficiencyViewModel = new WeaponProficiencyViewModel(SelectedWeaponProficiencies);
                SelectedArmorProficiencies = PR.ArmorProficiencies;
                ArmorProficiencyViewModel = new ArmorProficiencyViewModel(SelectedArmorProficiencies);
                SelectedToolProficiencies = PR.ToolProficiencies;
                ToolProficiencyViewModel = new ToolProficiencyViewModel(SelectedToolProficiencies);
                SelectedSkillProficiencies = PR.SkillProficiencies;
                SkillProficiencyViewModel = new SkillProficiencyViewModel(SelectedSkillProficiencies);
                SelectedLanguageProficiencies = PR.Languages;
                LanguageProficiencyViewModel = new LanguageProficiencyViewModel(SelectedLanguageProficiencies);
            }

            else resetStuff();
        }

        void SelectedParentRace_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }       
        public void AddWeaponProficiencies(object obj)
        {
            AddProficienciesView apv = new AddProficienciesView(WeaponProficiencyViewModel);
            apv.Show();
        }
        public void AddArmorProficiencies(object obj)
        {
            AddProficienciesView apv = new AddProficienciesView(ArmorProficiencyViewModel);
            apv.Show();
        }
        public void AddToolProficiencies(object obj)
        {
            AddProficienciesView apv = new AddProficienciesView(ToolProficiencyViewModel);
            apv.Show();
        }
        public void AddSkillProficiencies(object obj)
        {
            AddProficienciesView apv = new AddProficienciesView(SkillProficiencyViewModel);
            apv.Show();
        }
        public void AddLanguageProficiencies(object obj)
        {
            AddProficienciesView apv = new AddProficienciesView(LanguageProficiencyViewModel);
            apv.Show();
        }

        public void resetStuff()
        {
            if (SubraceChecked) SubraceChecked = false;
            Name = string.Empty;
            SelectedParentRace = ParentRaceList[0];
            Darkvision = DarkvisionList[0];
            Speed = SpeedList[0];
            Size = Size.Tiny;
            AbilityBonus = string.Empty;
            AbilityBonusViewModelList.Clear();
        }

        public void ResetAll(object obj)
        {
            if (SubraceChecked)SubraceChecked = false;
            Name = string.Empty;
            SelectedParentRace = ParentRaceList[0];
            Darkvision = DarkvisionList[0];
            Speed = SpeedList[0];
            Size = Size.Tiny;
            AbilityBonus = string.Empty;
            AbilityBonusViewModelList.Clear();

        }
        public void AddRaceToDB(object obj)
        {
            //if (obj.GetType() == typeof(StackPanel))
            //{
            //    StackPanel p = obj as StackPanel;
            //    StringBuilder sb = new StringBuilder();
            //    foreach (var a in p.Children)
            //    {
            //        if (a.GetType() == typeof(AbilityBonusView))
            //        {
            //            AbilityBonusView b = a as AbilityBonusView;
            //            //sb.Append(dbAbility(b.AbilityName.Text));
            //            if (!b.SelectedValue.Text.Contains('-')) sb.Append('+');
            //            sb.Append(b.SelectedValue.Text);
            //            sb.Append(",");
            //        }
            //    }
            //    AbilityBonus = sb.ToString();
            //}

            StringBuilder sbb = new StringBuilder();
            foreach (AbilityBonusViewModel a in AbilityBonusViewModelList)
            {
                sbb.Append(dbAbility(a.SelectedAbility.Description));
                if (!a.SelectedBonus.ToString().Contains('-')) sbb.Append('+');
                sbb.Append(a.SelectedBonus.ToString());
                sbb.Append(',');
            }
            AbilityBonus = sbb.ToString();

            //DBConverter.ConvertEnumBaseToBaseType(SelectedWeaponProficiencies);
            //DBConverter.ConvertEnumBaseToBaseType(SelectedArmorProficiencies);
            //DBConverter.ConvertEnumBaseToBaseType(SelectedLanguageProficiencies);
            //DBConverter.ConvertEnumBaseToBaseType(SelectedToolProficiencies);
            //DBConverter.ConvertEnumBaseToBaseType(SelectedSkillProficiencies);

            Utility.AddRaceToDB(Name, AbilityBonus, Size.ToString(), Speed, Darkvision,
                DBConverter.ConvertEnumBaseToBaseType(SelectedWeaponProficiencies),
                DBConverter.ConvertEnumBaseToBaseType(SelectedToolProficiencies),
                DBConverter.ConvertEnumBaseToBaseType(SelectedLanguageProficiencies),
                ParentRace, DBConverter.ConvertEnumBaseToBaseType(SelectedSkillProficiencies),
                DBConverter.ConvertEnumBaseToBaseType(SelectedArmorProficiencies)
                );
            MessageBox.Show("success");

            //Race createdRace = new Race
            //{
            //    Name = Name,
            //    AbiBonus =  AbilityBonus,
            //    ArmorProficiencies = SelectedArmorProficiencies,
            //    WeaponProficiencies = SelectedWeaponProficiencies,
            //    Darkvision = Darkvision,
            //    Size = Size.ToString(),
            //    Speed = Speed,

            //};

        }


        //Other Methods


        public bool DetectAbi(StackPanel sp)
        {
            return sp.Children.OfType<AbilityBonusView>().Any();
        }

        //Properties

        public bool CanExecute
        {
            get { return this.canExecute; }
            set {
                if (canExecute == value)
                {
                    return;
                }
                canExecute = value;
            }
        }

        public ObservableCollection<int> SpeedList
        {
            get { return _speedList; }

            set
            {
                if (_speedList != value)
                {
                    _speedList = value;
                    OnPropertyChanged("SpeedList");

                }
            }
        }
        public ObservableCollection<EnumBase> SizeList
        {
            get { return _sizeList; }

            set
            {
                if (_sizeList != value)
                {
                    _sizeList = value;
                    OnPropertyChanged("SizeList");

                }
            }
        }
        public ObservableCollection<string> DarkvisionList
        {
            get { return _darkvisionList; }

            set
            {
                if (_darkvisionList != value)
                {
                    _darkvisionList = value;
                    OnPropertyChanged("DarkvisionList");

                }
            }
        }

        public ObservableCollection<EnumBase> SelectedWeaponProficiencies
        {
            get { return _selectedWeaponProficiencies; }

            set
            {
                if (_selectedWeaponProficiencies != value)
                {
                    _selectedWeaponProficiencies = value;
                    OnPropertyChanged("SelectedWeaponProficiencies");

                }
            }
        }
        public ObservableCollection<EnumBase> SelectedArmorProficiencies
        {
            get { return _selectedArmorProficiencies; }

            set
            {
                if (_selectedArmorProficiencies != value)
                {
                    _selectedArmorProficiencies = value;
                    OnPropertyChanged("SelectedArmorProficiencies");

                }
            }
        }
        public ObservableCollection<EnumBase> SelectedToolProficiencies
        {
            get { return _selectedToolProficiencies; }

            set
            {
                if (_selectedToolProficiencies != value)
                {
                    _selectedToolProficiencies = value;
                    OnPropertyChanged("SelectedToolProficiencies");

                }
            }
        }
        public ObservableCollection<EnumBase> SelectedSkillProficiencies
        {
            get { return _selectedSkillProficiencies; }

            set
            {
                if (_selectedSkillProficiencies != value)
                {
                    _selectedSkillProficiencies = value;
                    OnPropertyChanged("SelectedSkillProficiencies");

                }
            }
        }
        public ObservableCollection<EnumBase> SelectedLanguageProficiencies
        {
            get { return _selectedLanguageProficiencies; }

            set
            {
                if (_selectedLanguageProficiencies != value)
                {
                    _selectedLanguageProficiencies = value;
                    OnPropertyChanged("SelectedLanguageProficiencies");

                }
            }
        }


        public WeaponProficiencyViewModel WeaponProficiencyViewModel { get; set; }
        public ArmorProficiencyViewModel ArmorProficiencyViewModel { get; set; }
        public ToolProficiencyViewModel ToolProficiencyViewModel { get; set; }


        private ViewModelBase _currentVM;
        public ViewModelBase CurrentVM
        {
            get { return _currentVM; }

            set
            {
                if (_currentVM != value)
                {
                    _currentVM = value;
                    OnPropertyChanged("CurrentVM");

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
        public Race Race
        {
            get { return new Race(); } 
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
        public string AbilityBonus
        {
            get { return _abilityBonus; }

            set
            {
                if (_abilityBonus != value)
                {
                    _abilityBonus = value;
                    OnPropertyChanged("AbilityBonus");
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
        public string ParentRace
        {
            get { return _parentRace; }

            set
            {
                if (_parentRace != value)
                {
                    _parentRace = value;
                    OnPropertyChanged("ParentRace");
                }
            }
        }





        private ObservableCollection<Race> _parentRaceList = RaceRepository.CreateParentRaceList();
        public ObservableCollection<Race> ParentRaceList
        {
            get { return _parentRaceList; }

            set
            {
                if (_parentRaceList != value)
                {
                    _parentRaceList = value;
                    OnPropertyChanged("ParentRaceList");

                }
            }
        }

        private Alignment _alignment;
        public Alignment SelectedAlignment
        {
            get { return _alignment; }
            set
            {
                if (value != _alignment)
                {
                    _alignment = value;
                    OnPropertyChanged("SelectedAlignment");
                }
            }
        }
        //Static Enumlists for binding comboboxes across app



    
    }
}
