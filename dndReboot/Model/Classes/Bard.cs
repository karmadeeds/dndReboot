using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dndReboot.Utilities;

namespace dndReboot.Model.Classes
{
    public class Bard : CharacterClass
    {
        private List<Feature> _bardfeatures;
        public List<Feature> BardFeatures
        {
            get
            {
                return _bardfeatures;
            }
            set
            {
                if (_bardfeatures != value)
                {
                    _bardfeatures = value;
                    ClearError("BardFeatures");
                    OnPropertyChanged("BardFeatures");
                }
            }
        }

        private BardCollege _college;
        public BardCollege College
        {
            get
            {
                return _college;
            }
            set
            {
                if (_college != value)
                {
                    _college = value;
                    ClearError("College");
                    OnPropertyChanged("College");
                }
            }
        }

        private Dice _bardicInspiration;
        public Dice BardicInspiration
        {
            get
            {
                return _bardicInspiration;
            }
            set
            {
                if (_bardicInspiration != value)
                {
                    _bardicInspiration = value;
                    ClearError("BardicInspiration");
                    OnPropertyChanged("BardicInspiration");
                }
            }
        }

        private Dice _songofrest;
        public Dice SongofRest
        {
            get
            {
                return _songofrest;
            }
            set
            {
                if (_songofrest != value)
                {
                    _songofrest = value;
                    ClearError("SongofRest");
                    OnPropertyChanged("SongofRest");
                }
            }
        }

        public Bard()
        {
            Name = "Bard";
            HitDice = Dice.d8;
            Level = 2;
            Spellcaster = true;
            Ritualcaster = true;
        }
    }
}
