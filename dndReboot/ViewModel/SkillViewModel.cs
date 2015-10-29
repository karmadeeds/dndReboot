using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows;
using dndReboot.Model;
using dndReboot.Utilities;

namespace dndReboot.ViewModel
{
    public class SkillViewModel : ViewModelBase
    {
        private Skill _skill;
        public Skill Skill
        {
            get { return _skill; }
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

        private bool _proficiency;
        public bool Proficiency
        {
            get { return _proficiency; }

            set
            {
                _proficiency = value;
                //UpdateBonus(CharacterViewModel.pBonus);
                OnPropertyChanged("Proficiency");
            }
        }


        public string Name
        {
            get { return Skill.Name; }
            set
            {
                Skill.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public SkillViewModel(Skill skill)
        {
            _skill = skill;
            Proficiency = skill.Proficiency;
        }

        public SkillViewModel(SkillProficiency skill)
        {
            _skill = new Skill(skill);
            Name = _skill.Name;
            PropertyChanged += skillViewModel_PropertyChanged;
        }

        private void skillViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Proficiency")
            {
                UpdateBonus(CharacterViewModel.pBonus);
            }
        }

        public void SetBonus(CharacterViewModel c, AbilityViewModel a)
        {
            if (Proficiency == false) Bonus = Math.Floor(((double)a.Value - 10) / 2);
            if (Proficiency) Bonus = Math.Floor(((double)a.Value - 10) / 2) + c.ProficiencyBonus;
        }

        public void SetBonus(int value, int prof)
        {
            if (Proficiency == false) Bonus = Math.Floor(((double)value - 10) / 2);
            if (Proficiency) Bonus = Math.Floor(((double)value - 10) / 2) + prof;
        }

        public void UpdateBonus(int pBonus)
        {
            if (Proficiency) Bonus += pBonus;
            if (!Proficiency) Bonus -= pBonus;
        }
    }

    public static class SkillProvider
    {
        public static ObservableCollection<SkillViewModel> GetSkills(SkillProficiency ability)
        {
            ObservableCollection<SkillViewModel> skills = new ObservableCollection<SkillViewModel>();

            foreach (SkillProficiency cs in ability.GetUniqueFlags())
            {
                skills.Add(new SkillViewModel(cs));
            }

            return skills;
        }
    }
}
