using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using dndReboot.DataAccess;
using dndReboot.Commands;
using dndReboot.Model;
using System.Windows.Input;
using System.Windows.Media;

namespace dndReboot.ViewModel
{
    public class CharacterViewModel : ViewModelBase
    {
        public string PageName
        {
            get { return "CharacterSheetView"; }
        }

        public static int pBonus;

        private Character _mycharacter;
        public Character MyCharacter
        {
            get {return _mycharacter;}
            set
            {
                if (_mycharacter != value)
                {
                    _mycharacter = value;
                    //OnPropertyChanged("MyCharacter");
                }
            }
        }

        private int _characterLevel;
        public int CharacterLevel
        {
            get { return _characterLevel; }

            set
            {
                if (_characterLevel != value)
                {
                    _characterLevel = value;
                    SetProfBonus();
                    OnPropertyChanged("CharacterLevel");

                }
            }
        }
        
        private int _xp;
        public int XP
        {
            get
            {
                return _xp;
            }
            set
            {
                if (_xp != value)
                {
                    _xp = value;
                    MyLevel();
                    OnPropertyChanged("XP");
                }
            }
        }

        private int _proficiencyBonus;
        public int ProficiencyBonus
        {
            get { return _proficiencyBonus; }
            set
            {
                if (_proficiencyBonus != value)
                {
                    _proficiencyBonus = value;
                    pBonus = value;
                    OnPropertyChanged("ProficiencyBonus");
                }
            }
        }

        public void MyLevel()
        {
            if (_xp < 300) CharacterLevel = 1;
            else if (300 <= _xp && _xp < 900) CharacterLevel = 2;
            else if (900 <= _xp && _xp < 2700) CharacterLevel = 3;
            else if (2700 <= _xp && _xp < 6500) CharacterLevel = 4;
            else if (6500 <= _xp && _xp < 14000) CharacterLevel = 5;
            else if (14000 <= _xp && _xp < 23000) CharacterLevel = 6;
            else if (23000 <= _xp && _xp < 34000) CharacterLevel = 7;
            else if (34000 <= _xp && _xp < 48000) CharacterLevel = 8;
            else if (48000 <= _xp && _xp < 64000) CharacterLevel = 9;
            else if (64000 <= _xp && _xp < 85000) CharacterLevel = 10;
            else if (85000 <= _xp && _xp < 100000) CharacterLevel = 11;
            else if (100000 <= _xp && _xp < 120000) CharacterLevel = 12;
            else if (120000 <= _xp && _xp < 140000) CharacterLevel = 13;
            else if (140000 <= _xp && _xp < 165000) CharacterLevel = 14;
            else if (165000 <= _xp && _xp < 195000) CharacterLevel = 15;
            else if (195000 <= _xp && _xp < 225000) CharacterLevel = 16;
            else if (225000 <= _xp && _xp < 265000) CharacterLevel = 17;
            else if (265000 <= _xp && _xp < 305000) CharacterLevel = 18;
            else if (305000 <= _xp && _xp < 355000) CharacterLevel = 19;
            else if (355000 <= _xp) CharacterLevel = 20;
        }
        
        public void SetProfBonus()
        {
            double c = CharacterLevel;
            var d = Math.Floor((c - 1) / 4) + 2;
            ProficiencyBonus = Convert.ToInt32(d);
        }
        
        private ObservableCollection<AbilityViewModel> _allAbilities;
        public ObservableCollection<AbilityViewModel> AllAbilities
        {
            get { return _allAbilities; }

            set
            {
                if (_allAbilities != value)
                {
                    _allAbilities = value;
                    OnPropertyChanged("AllAbilities");
                }
            }
        }

        private ObservableCollection<Ability> AbilityList; 

        public CharacterViewModel(Character nmc)
        {
            MyCharacter = nmc;
            //AllAbilities = nmc.Abilities;
            PropertyChanged += characterViewModel_PropertyChanged;
        }


        public ObservableCollection<AbilityViewModel> GetAbilityViewModels()
        {
            ObservableCollection<AbilityViewModel> temp = new ObservableCollection<AbilityViewModel>();
            foreach (Ability a in AbilityList)
            {
                temp.Add(new AbilityViewModel(a));
            }
            return temp;
        }
        public CharacterViewModel()
        {
            MyCharacter = new Character();
            AbilityList = MyCharacter.Abilities;
            AllAbilities = GetAbilityViewModels();
            XP = MyCharacter.XP;
            //AllAbilities = new ObservableCollection<Ability>
            //{
            //    new Ability("Strength"), new Ability("Dexterity"), new Ability("Constitution"), new Ability("Intelligence"), new Ability("Wisdom"), new Ability("Charisma")
            //};
            
            this.PropertyChanged += characterViewModel_PropertyChanged;
        }

        private void characterViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ProficiencyBonus")
            {
                foreach (AbilityViewModel a in AllAbilities)
                {
                    foreach (SkillViewModel s in a.Skills)
                    {
                        s.SetBonus(this, a);
                    }
                }
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected void OnPropertyChanged(string propertyName)
        //{
        //    if (this.PropertyChanged != null)
        //    {
        //        this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }

        //}

    }
}
