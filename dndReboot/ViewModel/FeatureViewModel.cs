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
    public class FeatureViewModel : ViewModelBase   
    {
        readonly FeatureRepository _featuresRepository;
        //RelayCommand featureCommand;
        
        
        public ObservableCollection<Feature> AllFeatures
        {
            get;
            private set;
        }
        
        public FeatureViewModel(FeatureRepository featuresRepository)
        {
            if (featuresRepository == null) throw new ArgumentNullException("featuresRepository");
            _featuresRepository = featuresRepository;
            this.AllFeatures = new ObservableCollection<Feature>(_featuresRepository.GetFeatures());
        }

        protected override void OnDispose()
        {
            this.AllFeatures.Clear();
        }


        public string Name
        {
            get { return "Features"; }
        }
    }
}
