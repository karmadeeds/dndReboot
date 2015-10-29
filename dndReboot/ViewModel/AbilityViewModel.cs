using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dndReboot.Model;
using System.Windows;
using dndReboot.DataAccess;
using dndReboot.Utilities;

namespace dndReboot.ViewModel
{
    public class AbilityViewModel : ViewModelBase
    {


        public string Name { get; set; }


        //private Ability _ability;

        private ObservableCollection<SkillViewModel> _skills;
        public ObservableCollection<SkillViewModel> Skills
        {
            get { return _skills; }

            set
            {
                if (_skills != value)
                {
                    _skills = value;
                    OnPropertyChanged("Skills");
                }
            }
        }

        private double _bonus;    
        public double Bonus
        {
            get { return _bonus; }

            set
            {
                if (_bonus != value)
                {
                    _bonus = value;
                    OnPropertyChanged("Bonus");

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
                    SetBonus();
                    OnPropertyChanged("Value");

                }
            }
        }


        public AbilityViewModel()
        {
            //Name = "Dexterity";
            //Value = 16;
            //_skills = SkillProvider.GetSkills(CharacterSkill.Dexterity);
            //_skills[0].Proficiency = true;
            //foreach (SkillViewModel s in _skills)
            //{
            //    if (!s.Proficiency)
            //    s.Bonus = SkillBonus();
            //    else if (s.Proficiency)
            //        s.Bonus = SkillBonus() + 2;
            //}
            
        }

        private void abilityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value")
            {
                foreach (SkillViewModel s in _skills)
                {
                    s.SetBonus(Value, CharacterViewModel.pBonus);
                }
            }
        }


        public AbilityViewModel(Ability a)
        {
            string name = a.Name;
            Name = name;
            PropertyChanged += abilityViewModelPropertyChanged;
            if (name == "Strength")
            {
                _skills = SkillProvider.GetSkills(SkillProficiency.Strength);
                //_skills = new ObservableCollection<SkillViewModel>
                //{
                //    new SkillViewModel(CharacterSkill.StrengthST),
                //    new SkillViewModel(CharacterSkill.Athletics)
                //};
            }
            else if (name == "Dexterity")
            {
                _skills = new ObservableCollection<SkillViewModel>
                {
                    new SkillViewModel(SkillProficiency.DexterityST),
                    new SkillViewModel(SkillProficiency.Acrobatics),
                    new SkillViewModel(SkillProficiency.SleightofHand),
                    new SkillViewModel(SkillProficiency.Stealth)
                };
            }
            else if (name == "Constitution")
            {
                _skills = new ObservableCollection<SkillViewModel>
                {
                    new SkillViewModel(SkillProficiency.ConstitutionST),
                };
            }
            else if (name == "Intelligence")
            {
                _skills = new ObservableCollection<SkillViewModel>
                {
                    new SkillViewModel(SkillProficiency.IntelligenceST),
                    new SkillViewModel(SkillProficiency.Arcana),
                    new SkillViewModel(SkillProficiency.History),
                    new SkillViewModel(SkillProficiency.Investigation),
                    new SkillViewModel(SkillProficiency.Nature),
                    new SkillViewModel(SkillProficiency.Religion)
                };
            }
            else if (name == "Wisdom")
            {
                _skills = new ObservableCollection<SkillViewModel>
                {
                    new SkillViewModel(SkillProficiency.WisdomST),
                    new SkillViewModel(SkillProficiency.AnimalHandling),
                    new SkillViewModel(SkillProficiency.Insight),
                    new SkillViewModel(SkillProficiency.Medicine),
                    new SkillViewModel(SkillProficiency.Perception),
                    new SkillViewModel(SkillProficiency.Survival)
                };
            }
            else if (name == "Charisma")
            {
                _skills = new ObservableCollection<SkillViewModel>
                {
                    new SkillViewModel(SkillProficiency.CharismaST),
                    new SkillViewModel(SkillProficiency.Deception),
                    new SkillViewModel(SkillProficiency.Intimidation),
                    new SkillViewModel(SkillProficiency.Performance),
                    new SkillViewModel(SkillProficiency.Persuasion),
                };
            }

            Value = a.Value;
            SetBonus();

        }

        public void SetBonus()
        {
            Bonus = Math.Floor(((double) Value - 10)/2);
        }

        public double SkillBonus()
        {
            return Math.Floor(((double) Value - 10)/2);
        }
    }
}
