using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dndReboot.Model;
using dndReboot.Utilities;

namespace dndReboot.ViewModel
{
    public class AbilityBonusViewModel : ViewModelBase
    {


        private ObservableCollection<EnumBase> _abilityList = new ObservableCollection<EnumBase>(EnumHelper.GetAllEnumsOfType<AbilityEnums>());
        public ObservableCollection<EnumBase> AbilityList
        {
            get { return _abilityList; }

            set
            {
                if (_abilityList != value)
                {
                    _abilityList = value;
                    OnPropertyChanged("AbilityList");

                }
            }
        }

        private ObservableCollection<int> _abilityValueList = new ObservableCollection<int>{-2,-1,0,+1,+2};
        public ObservableCollection<int> AbilityValueList
        {
            get { return _abilityValueList; }

            set
            {
                if (_abilityValueList != value)
                {
                    _abilityValueList = value;
                    OnPropertyChanged("AbilityValueList");

                }
            }
        }

        private EnumBase _selectedAbility;
        public EnumBase SelectedAbility
        {
            get { return _selectedAbility; }

            set
            {
                if (_selectedAbility != value)
                {
                    _selectedAbility = value;
                    OnPropertyChanged("SelectedAbility");

                }
            }
        }


        private int _selectedBonus;
        public int SelectedBonus
        {
            get { return _selectedBonus; }

            set
            {
                if (_selectedBonus != value)
                {
                    _selectedBonus = value;
                    OnPropertyChanged("SelectedBonus");

                }
            }
        }

        public AbilityBonusViewModel()
        {
            
        }

        public AbilityBonusViewModel(int abilityIndex, int valueIndex)
        {
            SelectedAbility = AbilityList[abilityIndex];
            SelectedBonus = valueIndex;
        }

        public AbilityBonusViewModel(string s, int valueIndex)
        {
            SelectedAbility = new EnumBase(Utility.ParseEnum<AbilityEnums>(s));
            SelectedBonus = valueIndex;
        }

    }
}
