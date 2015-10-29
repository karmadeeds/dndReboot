using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using dndReboot.DataAccess;
using dndReboot.Commands;
using dndReboot.Model;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace dndReboot.ViewModel
{ 
    class RaceListViewModel : ViewModelBase
    {
        public string Name { get { return "RaceList"; } }
        readonly RaceRepository _raceRepository;

        //RelayCommand _invasionCommand;

        public ObservableCollection<Model.Race> AllRaces
        {
            get;
            private set;
        }

        //public ObservableCollection<RaceViewModel> RaceViewModels { get; private set; }


        public RaceListViewModel(RaceRepository raceRepository)
        {
            if (raceRepository == null)
            {
                throw new ArgumentNullException("raceRepository");
            }
            _raceRepository = raceRepository;
            this.AllRaces = new ObservableCollection<Model.Race>(_raceRepository.GetRaces());

        }

        //for use in testing without a repository setup
        //public RaceListViewModel()
        //{
        //    RaceViewModels = new ObservableCollection<RaceViewModel>();
            
        //    Feature racialFeature = new Feature();
        //    racialFeature.Name = "Relentless Endurance";
        //    racialFeature.Explanation =
        //        "When you are reduced to 0 hit points but not killed outright, you can drop to 1 hit point instead. You can't use this feature again until you finish a long rest.";
        //    Feature racialFeature2 = new Feature();
        //    racialFeature2.Name = "Drow Stuff";
        //    racialFeature2.Explanation = "This is a lot of other stuff";
        //    Race r = new Race
        //    {
        //        Name = "Half-Orc",
        //        Speed = 30,
        //        Size = "Medium",
        //        Darkvision = "60 feet",
        //        AbilityScoreBonuses = new ObservableCollection<AbilityBonus> { new AbilityBonus(Abi.Strength, 2), new AbilityBonus(Abi.Constitution, 1) },
        //        Proficiencies = new ObservableCollection<Proficiency> { Proficiency.Athletics },
        //        Languages = new ObservableCollection<Language> { Language.Orc, Language.Common },
        //        RacialTraits = new ObservableCollection<Feature>
        //        {
        //            racialFeature,
        //            racialFeature2
        //        }
        //    };
        //    RaceViewModels.Add(new RaceViewModel());
        //}

        protected override void OnDispose()
        {
            this.AllRaces.Clear();
        }

        private Brush _bgBrush;
        public Brush BackgroundBrush
        {
            get
            {
                return _bgBrush;
            }
            set
            {
                _bgBrush = value;
                OnPropertyChanged("BackgroundBrush");
            }
        }






       
    }
}
