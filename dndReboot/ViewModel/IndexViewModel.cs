using System.Collections.ObjectModel;
using dndReboot.DataAccess;
using dndReboot.Model;
using dndReboot.Commands;
using System.Windows.Input;
using System.Collections.Generic;

namespace dndReboot.ViewModel
{
    public class IndexViewModel : ViewModelBase
    {
        readonly RaceRepository _raceRepository;
        readonly CharacterRepository _characterRepository;
        //readonly FeatureRepository _featureRepository;

        ObservableCollection<ViewModelBase> _viewModels;
        ObservableCollection<ViewModelBase> _cViewModels;
        ObservableCollection<ViewModelBase> _fViewModels;

        public IndexViewModel()
        {
            _raceRepository = new RaceRepository();
            _characterRepository = new CharacterRepository();

            //create an instance of our viewmodel that we want to display and add it to our collection
            RaceListViewModel viewModel = new RaceListViewModel(_raceRepository);
            //CharacterViewModel cViewModel = new CharacterViewModel(_characterRepository);

            this.ViewModels.Add(viewModel);
            //this.CViewModels.Add(cViewModel);

        }

        public ObservableCollection<ViewModelBase> ViewModels
        {
            get
            {
                if (_viewModels == null)
                {
                    _viewModels = new ObservableCollection<ViewModelBase>();
                }
                return _viewModels;
            }
        }
        public ObservableCollection<ViewModelBase> CViewModels
        {
            get
            {
                if (_cViewModels == null)
                {
                    _cViewModels = new ObservableCollection<ViewModelBase>();
                }
                return _cViewModels;
            }
        }
        public ObservableCollection<ViewModelBase> FViewModels
        {
            get
            {
                if (_fViewModels == null)
                {
                    _fViewModels = new ObservableCollection<ViewModelBase>();
                }
                return _fViewModels;
            }
        }
      
        public string Name
        {
            get { return "Index"; }
        }
    }
}
