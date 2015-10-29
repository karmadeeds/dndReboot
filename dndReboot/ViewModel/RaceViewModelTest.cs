using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using dndReboot.Commands;
using dndReboot.Model;
using dndReboot.DataAccess;
using dndReboot.Utilities;

namespace dndReboot.ViewModel
{
    public class RaceViewModelTest : ViewModelBase
    {
        private Race _race;
        public Race Race
        {
            get { return _race; }

            set
            {
                if (_race != value)
                {
                    _race = value;
                    OnPropertyChanged("Race");
                }
            }
        }

        public string TestName { get; set; }

        private ObservableCollection<Race> _allRaces;
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



        //public DataSet ds { get; set; }

        public RaceViewModelTest()
        {
            Race = RaceRepository.CreateRace("High Elf");
            TestName = "Original Loading";
            AllRaces = RaceRepository.CreateRaceList();
            //SQLiteConnection con = new SQLiteConnection(@"Data Source=FreeDataBase.sqlite;Version=3;");
            //string sql = "SELECT * FROM Race";
            //ds = new DataSet();
            //SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sql, con);
            //dataAdapter.Fill(ds);


        }


        
    }
}
