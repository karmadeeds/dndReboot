using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using dndReboot.Model;

namespace dndReboot.Utilities
{
    public class EnumBase : INotifyPropertyChanged
    {
        private string _description;
        public string Description
        {
            get { return _description; }

            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");

                }
            }
        }

        private Enum _value;
        public Enum Value
        {
            get { return _value; }

            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged("Value");

                }
            }
        }

        private bool _isProficient;
        public bool IsProficient
        {
            get { return _isProficient; }

            set
            {
                if (_isProficient != value)
                {
                    _isProficient = value;
                    OnPropertyChanged("IsProficient");

                }
            }
        }

        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }

            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    OnPropertyChanged("IsChecked");

                }
            }
        }

        public EnumBase()
        {
            //PropertyChanged += EnumBase_PropertyChanged;
        }
        
        public EnumBase(Enum myEnum)
        {
            Value = myEnum;
        }

        public EnumBase(WeaponProficiency weaponProficiency) : base()
        {
            Value = weaponProficiency;
            Description = weaponProficiency.Description();
            
        }

        public EnumBase(ArmorProficiency armorProficiency)
        {
            Value = armorProficiency;
            Description = armorProficiency.Description();
        }

        public EnumBase(ToolProficiency toolProficiency)
        {
            Value = toolProficiency;
            Description = toolProficiency.Description();
        }

        public EnumBase(Language language)
        {
            Value = language;
            Description = language.Description();
        }

        public EnumBase(SkillProficiency skillProficiency)
        {
            Value = skillProficiency;
            Description = skillProficiency.Description();
        }

        public EnumBase(AbilityEnums ability)
        {
            Value = ability;
            Description = ability.Description();
        }

        void EnumBase_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsChecked")
                MessageBox.Show("hi");
        }

        void EnumBaseConvert()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
