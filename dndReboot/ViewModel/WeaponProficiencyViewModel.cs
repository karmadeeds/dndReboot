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
using dndReboot.Model;
using dndReboot.Utilities;

namespace dndReboot.ViewModel
{
    public class WeaponProficiencyViewModel : ViewModelBase
    {
        private ObservableCollection<EnumBase> _allProficiencies = new ObservableCollection<EnumBase>(EnumHelper.GetAllEnumsOfType<WeaponProficiency>());
        private ObservableCollection<EnumBase> _selectedProficiencies = new ObservableCollection<EnumBase>();
        public ObservableCollection<EnumBase> AllProficiencies
        {
            get { return _allProficiencies; }
            set
            {
                if (_allProficiencies != value)
                {
                    _allProficiencies = value;
                    OnPropertyChanged("AllProficiencies");
                }
            }
        }
        public ObservableCollection<EnumBase> SelectedProficiencies
        {
            get { return _selectedProficiencies; }
            set
            {
                if (_selectedProficiencies != value)
                {
                    _selectedProficiencies = value;
                    OnPropertyChanged("SelectedProficiencies");
                }
            }
        }

        public WeaponProficiencyViewModel()
        {
            DoStuffCommand = new RelayCommand(DoWork, param => canExecute);
            
            foreach (var item in AllProficiencies)
            {
                item.PropertyChanged += EnumBase_PropertyChanged;
            }

        }

        public WeaponProficiencyViewModel(ObservableCollection<EnumBase> selectedEnums)
        {
            DoStuffCommand = new RelayCommand(DoWork, param => canExecute);
            ConfirmCommand = new TypeCommand<Window>(ConfirmStuff);
            SelectedProficiencies = selectedEnums;
            //if (selectedEnums == null) SelectedProficiencies = new ObservableCollection<EnumBase>();
            foreach (var item in AllProficiencies)
            {
                item.PropertyChanged += EnumBase_PropertyChanged;
            }
            foreach (var item in SelectedProficiencies)
            {
                foreach (var item2 in AllProficiencies)
                {
                    if (item.Description == item2.Description)
                    {
                        item2.IsChecked = true;
                    }
                }
            }
        }

        public void ConfirmStuff(Window window)
        {
            window.Close();
        }

        private bool canExecute = true;
        public bool CanExecute
        {
            get { return this.canExecute; }
            set
            {
                if (canExecute == value)
                {
                    return;
                }
                canExecute = value;
            }
        }

        private ICommand _confirmCommand;
        public ICommand ConfirmCommand
        {
            get { return _confirmCommand; }

            set
            {
                if (_confirmCommand != value)
                {
                    _confirmCommand = value;
                    OnPropertyChanged("ConfirmCommand");

                }
            }
        }

        private ICommand _doStuffCommand;
        public ICommand DoStuffCommand
        {
            get { return _doStuffCommand; }

            set
            {
                if (_doStuffCommand != value)
                {
                    _doStuffCommand = value;
                    OnPropertyChanged("DoStuffCommand");

                }
            }
        }


        private void SelectedProficiencies_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (EnumBase item in e.NewItems)
                {
                    //item.PropertyChanged += EnumBase_PropertyChanged; 
                }
            }

            if (e.OldItems != null)
            {
                foreach (EnumBase item in e.OldItems)
                {
                    //item.PropertyChanged -= EnumBase_PropertyChanged;
                }
            }
        }

        void EnumBase_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            EnumBase item = sender as EnumBase;
            if (e.PropertyName == "IsChecked")
            {
                if (item.IsChecked)
                {
                    if (!SelectedProficiencies.Contain(item))
                    {
                        SelectedProficiencies.Add(item);
                    }
                }
                if (item.IsChecked == false)
                {
                    if (SelectedProficiencies.Contain(item))
                    {
                        foreach (var item2 in SelectedProficiencies)
                        {
                            if (item2.Description == item.Description)
                            {
                                SelectedProficiencies.Remove(item2);
                            }
                        }
                    }
                }
            }
        }

        void DoWork(object obj)
        {
            foreach (var item in SelectedProficiencies)
            {
                if (AllProficiencies.Contain(item))
                {
                    MessageBox.Show(item.Description);
                }
            }
        }


    }
}
