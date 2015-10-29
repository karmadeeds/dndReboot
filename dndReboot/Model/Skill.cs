using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using dndReboot.Utilities;
using dndReboot.ViewModel;


namespace dndReboot.Model
{
    public class Skill : DependencyObject, INotifyPropertyChanged
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

        private bool _proficiency;
        public bool Proficiency
        {
            get { return _proficiency; }

            set
            {
                if (_proficiency != value)
                {
                    _proficiency = value;
                    OnPropertyChanged("Proficiency");

                }
            }
        }


        
        //private static void OnProficiencyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        //{
        //    Skill s = (Skill) sender;
        //    character = new Character();

        //    bool bnew = (bool) e.NewValue;
        //    //bool bold = (bool) e.OldValue;
        //    if (bnew)
        //    {
        //        s.Bonus += character.ProficiencyBonus;
        //    }
        //    if (bnew == false)
        //    {
        //        s.Bonus -= character.ProficiencyBonus;
        //    }

        //    s.Passive = 10 + s.Bonus;
        //}


        public static Skill CreateSkill(string name, bool proficiency)
        {
            return new Skill
            {
                _name = name,
                _proficiency = proficiency
            };
        }

        public static Skill CreateNewSkill()
        {
            return new Skill();
        }

        public Skill(SkillProficiency skill)
        {
            _name = skill.Description();
        }

        public Skill()
        {
            _proficiency = false;
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
