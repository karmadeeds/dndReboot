using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using dndReboot.View;
using dndReboot.Commands;
using dndReboot.DataAccess;
using dndReboot.Model.Classes;
using dndReboot.Model;
using dndReboot.Utilities;
using NotifyTest;

namespace dndReboot.ViewModel
{
    public class CharacterCreationViewModel : PropertyNotificationObject
    {
        public ICommand UpdateListCommand {get { return new RelayCommand(UpdateList); }}
        public ICommand TestCommand { get; set;}

        public void Test(object obj)
        {
            DataGrid db = obj as DataGrid;
            foreach (var item in db.Items)
            {
                MessageBox.Show(item.ToString());
            }
            //db.ItemsSource = AllRaces;
        }

        public void UpdateList(object obj)
        {
            RaceViewModelTest = new RaceViewModelTest();
            (obj as RaceViewGrid).DataContext = RaceViewModelTest;
        }

        public string PageName
        {
            get { return "Create a Character"; }
        }

        public override string DisplayName { get { return "CCVM"; } protected set {} }
        private Character _newCharacter;
        public Character NewCharacter
        {
            get { return _newCharacter; }
            set
            {
                if (_newCharacter != value)
                {
                    _newCharacter = value;
                   // OnPropertyChanged("NewCharacter");

                }
            }
        }

        public RaceViewModelTest RaceViewModelTest { get; set; }

        public static Character SharedCharacter;
        private Race _selectedRace;

        public Race SelectedRace
        {
            get { return _selectedRace; }

            set
            {
                SetProperty("SelectedRace", ref _selectedRace, value);
                //if (_selectedRace != value)
                //{
                //    _selectedRace = value;
                //    SetProperty("SelectedRace", ref _selectedRace, value);
                //    OnPropertyChanged("SelectedRace");

                //}
            }
        }

        private ObservableCollection<Race> _allRaces = RaceRepository.CreateRaceList();

        public ObservableCollection<Race> AllRaces
        {
            get { return _allRaces; }

            set
            {
                if (_allRaces != value)
                {
                    _allRaces = value;
                    OnPropertyChanged("AllRaces");

                }
            }
        }



        public int Strength;
        public int Dexterity;
        public int Constitution;
        public int Intelligence;
        public int Wisdom;
        public int Charisma;

        public string CharacterName { get; set; }


        // CONSTRUCTORS
        public CharacterCreationViewModel()
        {
            TestCommand = new RelayCommand(Test);
            NewCharacter = new Character();
            //Strength = NewCharacter.Str.Value;
            //Dexterity = NewCharacter.Dex.Value;
            //Constitution = NewCharacter.Con.Value;
            //Intelligence = NewCharacter.Int.Value;
            //Wisdom = NewCharacter.Wis.Value;
            //Charisma = NewCharacter.Chr.Value;
            RaceViewModelTest = new RaceViewModelTest();
            SelectedRace = new Race();
            RaceViewModelTest.TestName = "Changed Name";
            //PropertyChanged += CharacterCreationViewModel_PropertyChanged;
            PropertyChanging +=CharacterCreationViewModel_PropertyChanging;
        }

        void CharacterCreationViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            MessageBox.Show("hi");
        }





        //ENUM BINDING ATTEMPT
        public IEnumerable<EnumBase> AlignmentList
        {
            get { return EnumHelper.GetAllEnumsOfType<Alignment>(); }
        }

        public ObservableCollection<Race> RaceList
        {
            get { return RaceRepository.CreateRaceList(); }
        }

        public IEnumerable<EnumBase> BackgroundList
        {
            get { return EnumHelper.GetAllEnumsOfType<Background>(); }
        }


        void CharacterCreationViewModel_PropertyChanging(object sender, CancelPropertyNotificationEventArgs e)
        {
            MessageBox.Show("hi");
            if (e.PropertyName == "SelectedRace")
            {
                Race oldR = (Race)e.OldValue;
                Race newR = (Race)e.NewValue;
                string s = String.Format("Old Value is {0}, New Value is {1}", oldR.Name, newR.Name);
                MessageBox.Show(s);
            }
            //SharedCharacter = NewCharacter;
        }

        private Alignment _alignment;
        public Alignment SelectedAlignment
        {
            get { return _alignment; }
            set
            {
                SetProperty("SelectedAlignment", ref _alignment, value);
            }
        }



        private Background _background;

        public Background SelectedBackground
        {
            get {return _background;}
            set
            {
                SetProperty("SelectedBackground", ref _background, value);
            }
        }

        public void AbilityBonusUpdate()
        {
            NewCharacter.Dex.Value += 1;
        }

        //private void RaceAbilityModifiers(Race oldValue, Race newValue)
        //{
        //    if (oldValue == RaceList[0])
        //    {
        //        newValue.AbilityBonus(NewCharacter);
        //    }
        //    if (oldValue != RaceEnum.None)
        //    {
        //        oldValue.AbilityDeBonus(NewCharacter);
        //        newValue.AbilityBonus(NewCharacter);
        //    }
        //}

        

    }
}
