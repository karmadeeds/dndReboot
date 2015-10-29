using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using dndReboot.Utilities;

namespace dndReboot.Model
{
    public class Feature : ModelBase
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    ClearError("Name");
                    OnPropertyChanged("Name");
                }
            }
        }

        private string _explanation;
        public string Explanation
        {
            get
            {
                return _explanation;
            }
            set
            {
                if (_explanation != value)
                {
                    _explanation = value;
                    ClearError("Explanation");
                    OnPropertyChanged("Explanation");
                }
            }
        }

        private int _uses;
        public int Uses
        {
            get
            {
                return _uses;
            }
            set
            {
                if (_uses != value)
                {
                    _uses = value;
                    ClearError("Uses");
                    OnPropertyChanged("Uses");
                }
            }
        }
        
        private string _class;
        public string Class
        {
            get
            {
                return _class;
            }
            set
            {
                if (_class != value)
                {
                    _class = value;
                    ClearError("Class");
                    OnPropertyChanged("Class");
                }
            }
        }

        private int _level;
        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                if (_level != value)
                {
                    _level = value;
                    ClearError("Level");
                    OnPropertyChanged("Level");
                }
            }
        }

        private FeatureType _featuretype;
        public FeatureType FeatureType
        {
            get
            {
                return _featuretype;
            }
            set
            {
                if (_featuretype != value)
                {
                    _featuretype = value;
                    ClearError("FeatureType");
                    OnPropertyChanged("FeatureType");
                }
            }
        }

        private int _range;
        public int Range
        {
            get
            {
                return _range;
            }
            set
            {
                if (_range != value)
                {
                    _range = value;
                    ClearError("Range");
                    OnPropertyChanged("Range");
                }
            }
        }

        private string _duration;
        public string Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    ClearError("Duration");
                    OnPropertyChanged("Duration");
                }
            }
        }

        private CastingTime _castingtime;
        public CastingTime CastingTime
        {
            get
            {
                return _castingtime;
            }
            set
            {
                if (_castingtime != value)
                {
                    _castingtime = value;
                    ClearError("CastingTime");
                    OnPropertyChanged("CastingTime");
                }
            }
        }

        private Recovery _recovery;
        public Recovery Recovery
        {
            get
            {
                return _recovery;
            }
            set
            {
                if (_recovery != value)
                {
                    _recovery = value;
                    ClearError("Recovery");
                    OnPropertyChanged("Recovery");
                }
            }
        }

        private Targets _targets;
        public Targets Targets
        {
            get
            {
                return _targets;
            }
            set
            {
                if (_targets != value)
                {
                    _targets = value;
                    ClearError("Targets");
                    OnPropertyChanged("Targets");
                }
            }
        }

        private Dice _dice;
        public Dice Dice
        {
            get
            {
                return _dice;
            }
            set
            {
                if (_dice != value)
                {
                    _dice = value;
                    ClearError("Dice");
                    OnPropertyChanged("Dice");
                }
            }
        }

        private AreaofEffect _areaofeffect;
        public AreaofEffect AreaofEffect
        {
            get
            {
                return _areaofeffect;
            }
            set
            {
                if (_areaofeffect != value)
                {
                    _areaofeffect = value;
                    ClearError("AreaofEffect");
                    OnPropertyChanged("AreaofEffect");
                }
            }
        }

        public Feature()
        {

        }

        public Feature(string name)
        {
            using (SQLiteConnection con = new SQLiteConnection(@"Data Source=database.db;Version=3;"))
            {
                con.Open();
                using (SQLiteCommand fmd = con.CreateCommand())
                {
                    //Query string, need to change
                    fmd.CommandText = String.Format("SELECT * FROM features WHERE name = \"{0}\"", name);
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader dr = fmd.ExecuteReader();
                    while (dr.Read())
                    {
                        for (int ii = 0; ii < 12; ii++)
                        {
                            if (dr.IsDBNull(ii) == false)
                            {
                                switch (ii)
                                {

                                    //Name
                                    case 0:
                                        Name = dr.GetString(ii);
                                        break;
                                    //Explanation
                                    case 1:
                                        Explanation = dr.GetValue(ii).ToString();
                                        break;
                                    //Type
                                    case 2:
                                        {
                                            string foo = dr.GetValue(ii).ToString();
                                            if (foo == "Passive")
                                            {
                                                FeatureType = FeatureType.Passive;
                                            }
                                            else if (foo == "Active")
                                            {
                                                FeatureType = FeatureType.Active;
                                            }
                                            else if (foo == "Triggered")
                                            {
                                                FeatureType = FeatureType.Triggered;
                                            }
                                            else
                                            {
                                                FeatureType = FeatureType.Other;
                                            }
                                            break;
                                        }
                                    //CastingTime
                                    case 3:
                                        {
                                            string temp = dr.GetValue(ii).ToString();
                                            if (temp == "Action")
                                            {
                                                CastingTime = CastingTime.Action;
                                            }
                                            else if (temp == "BonusAction")
                                            {
                                                CastingTime = CastingTime.BonusAction;
                                            }
                                            else if (temp == "Reaction")
                                            {
                                                CastingTime = CastingTime.Reaction;
                                            }
                                            else CastingTime = CastingTime.Other;
                                            break;
                                        }
                                    //AreaofEffect
                                    case 4:
                                        {
                                            string temp = dr.GetString(ii);

                                            break;
                                        }
                                    //Dice
                                    case 5:
                                        {
                                            string temp = dr.GetString(ii);
                                            Enum.TryParse<Dice>(temp, out _dice);
                                            break;
                                        }
                                    //Duration
                                    case 6:
                                    //Range
                                    case 7:
                                    //Targets
                                    case 8:
                                    //Recovery
                                    case 9:
                                    //Class
                                    case 10:
                                        Class = dr.GetValue(ii).ToString();
                                        break;
                                    //Level
                                    case 11:
                                        Level = int.Parse(dr.GetValue(ii).ToString());
                                        break;
                                    default:
                                        {
                                            MessageBox.Show("invalid");
                                            break;
                                        }
                                }
                            }
                        }
                    }

                }
            }
        }
    }
}
