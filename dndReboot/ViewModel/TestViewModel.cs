using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using dndReboot.Commands;
using dndReboot.DataAccess;
using dndReboot.Model;
using dndReboot.Utilities;

namespace dndReboot.ViewModel
{
    public class TestViewModel : ViewModelBase
    {
        public TestViewModel()
        {
            ButtonCommand = new RelayCommand(Command);
            SelectedRace = AllRaces[3];
        }

        private Race _selectedRace;
        public Race SelectedRace
        {
            get { return _selectedRace; }

            set
            {
                if (_selectedRace != value)
                {
                    _selectedRace = value;
                    OnPropertyChanged("SelectedRace");

                }
            }
        }

        public Boolean IsSelected { get; set; }

        public bool canExecute = true;
        public void Command(object obj)
        {
            MessageBox.Show(SelectedRace.Name);
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


        private ObservableCollection<AbilityBonusViewModel> _viewModels;
        public ObservableCollection<AbilityBonusViewModel> ViewModels
        {
            get { return _viewModels; }

            set
            {
                if (_viewModels != value)
                {
                    _viewModels = value;
                    OnPropertyChanged("ViewModels");

                }
            }
        }


        public string PageName {get { return "TestView"; }}
        public ICommand ButtonCommand { get; set; }
        public static ICommand SelectCommand { get; set; }
        private string _input;

        public string Input
        {
            get { return _input; }

            set
            {
                if (_input != value)
                {
                    _input = value;
                    OnPropertyChanged("Input");

                }
            }
        }

        private string _output;

        public string Output
        {
            get { return _output; }

            set
            {
                if (_output != value)
                {
                    _output = value;
                    OnPropertyChanged("Output");

                }
            }
        }

        private ObservableCollection<string> _stringList;

        public ObservableCollection<string> StringList
        {
            get { return _stringList; }

            set
            {
                if (_stringList != value)
                {
                    _stringList = value;
                    OnPropertyChanged("StringList");

                }
            }
        }

        
    }
}
