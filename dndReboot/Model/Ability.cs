using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using dndReboot.ViewModel;

namespace dndReboot.Model
{
    public class Ability : DependencyObject, INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }

            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private int _value;
        public int Value
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

        //private ObservableCollection<Skill> _skills;
        //public ObservableCollection<Skill> Skills
        //{
        //    get { return _skills; }
        //    set
        //    {
        //        if (_skills != value)
        //        {
        //            _skills = value;
        //            OnPropertyChanged("Skills");
        //        }
        //    }
        //}


        //private int _passive;
        //public int Passive
        //{
        //    get
        //    {
        //        return _passive;
        //    }
        //    set
        //    {
        //        if (_passive != value)
        //        {
        //            _passive = value;
        //            OnPropertyChanged("Passive");
        //        }
        //    }
        //}

        //private int _bonus;
        //public int Bonus
        //{
        //    get { return _bonus; }

        //    set
        //    {
        //        if (_bonus != value)
        //        {
        //            _bonus = value;
        //            OnPropertyChanged("Bonus");

        //        }
        //    }
        //}

        public static Ability CreateAbility(string name)
        {
            return new Ability
            {
                _name = name
            };
        }

        public Ability()
        {
        }

        public Ability(string name)
        {
            _name = name;
            Value = 10;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
