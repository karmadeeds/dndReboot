using System.Collections.ObjectModel;
using dndReboot.DataAccess;
using dndReboot.Model;
using dndReboot.Commands;
using System.Windows.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using dndReboot.View;


namespace dndReboot.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        
       //Navigation Stuff taken from rachel lim blog
        private ICommand _changePageCommand;
        private ICommand _changePageViewModelCommand;
        private UserControl _currentPageView;
        private ViewModelBase _currentPageViewModel;
        private List<UserControl> _pageViews;
        private List<ViewModelBase> _pageViewModels; 
        public int index { get; set; }
        public static CharacterCreationViewModel cc = new CharacterCreationViewModel();
        //ObservableCollection<ViewModelBase> _viewModels;
        //ObservableCollection<ViewModelBase> _cViewModels;
        //ObservableCollection<ViewModelBase> _fViewModels;

        public MainWindowViewModel()
        {
 
            //add available pages
            //UserControl indexView = new IndexView();
            //UserControl raceView = new RaceListView();
            //UserControl abilityView = new AbilityView();
            UserControl creationView = new CharacterCreationView();
            UserControl newView = new CharacterSheetView();
            //UserControl raceView = new RaceViewGrid();
            UserControl raceCreationView = new AddRaceView();
            UserControl testView = new TestView();
            
            //UserControl characterView = new CharacterView();
            PageViewModels.Add(new CharacterViewModel());
            PageViewModels.Add(cc);
            PageViewModels.Add(new RaceCreationViewModel());
            PageViewModels.Add(new TestViewModel());
            //PageViewModels.Add(new RaceListViewModel(new RaceRepository()));
            //PageViewModels.Add(new AbilityViewModel());
            //PageViewModels.Add(new IndexViewModel());

            PageViews.Add(newView);
            PageViews.Add(creationView);
            PageViews.Add(raceCreationView);
            PageViews.Add(testView);
            //PageViews.Add(raceView);
            //PageViews.Add(abilityView);
            //PageViews.Add(indexView);

            //PageViewModels.Add(new CharacterViewModel());



            CurrentPageView = PageViews[1];

        }

        private void ChangeViewModel(ViewModelBase viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);
            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);
            index = PageViewModels.IndexOf(CurrentPageViewModel);
            //MessageBox.Show(index.ToString());
            CurrentPageView = PageViews[index];

        }
        private void ChangeView(UserControl view)
        {
            if (!PageViews.Contains(view))
                PageViews.Add(view);
            CurrentPageView = PageViews.FirstOrDefault(vm => vm == view);

        }

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeView((UserControl)p),
                        p => p is UserControl);
                }
                return _changePageCommand;
            }
        }
        public ICommand ChangePageViewModelCommand
        {
            get
            {
                if (_changePageViewModelCommand == null)
                {
                    _changePageViewModelCommand = new RelayCommand(
                        p => ChangeViewModel((ViewModelBase)p),
                        p => p is ViewModelBase);
                }
                return _changePageViewModelCommand;
            }
        }

        public List<ViewModelBase> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<ViewModelBase>();
                return _pageViewModels;
            }
        }
        public List<UserControl> PageViews
        {
            get
            {
                if (_pageViews == null)
                    _pageViews = new List<UserControl>();
                return _pageViews;
            }

        }

        public UserControl CurrentPageView
        {
            get { return _currentPageView; }
            set
            {
                if (_currentPageView != value)
                {
                    _currentPageView = value;
                    OnPropertyChanged("CurrentPageView");
                }
            }
        }
        public ViewModelBase CurrentPageViewModel
        {
            get { return _currentPageViewModel; }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageView");
                }
            }
        }

    }
}
