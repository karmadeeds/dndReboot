using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using dndReboot.Model;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using dndReboot.Utilities;
using dndReboot.ViewModel;

namespace dndReboot.DataAccess
{
    public class RaceRepository
    {

        private static Race None = new Race();
        readonly List<Race> _races;
        private readonly List<Race> _parentRaces; 
        public RaceRepository()
        {
            if (_races == null)
            {
                _races = new List<Race>();
            }
            if (_parentRaces == null)
            {
                _parentRaces = new List<Race>();
            }
            
        }
        
        public event EventHandler<RaceAddedEventArgs> RaceAdded;

        public void AddRace(Race race)
        {
            if (race == null) throw new ArgumentNullException("race");

            if (!_races.Contains(race))
            {
                _races.Add(race);
                if (this.RaceAdded != null)
                    this.RaceAdded(this, new RaceAddedEventArgs(race));
            }
        }

        public bool ContainsRace(Race race)
        {
            if (race == null)
                throw new ArgumentNullException("race");
            return _races.Contains(race);
        }

        public List<Race> GetRaces()
        {
            return new List<Race>(_races);
        }
        public static Race CreateRace(string query)
        {
            Race newRace = new Race();
            string dbConnectionString = @"Data Source=FreeDataBase.sqlite;Version=3;";
            SQLiteConnection con = new SQLiteConnection(dbConnectionString);
            con.Open();
            string q = String.Format("SELECT * FROM Race WHERE Name = '{0}'", query);
            string mainrace = string.Empty;

            SQLiteCommand command = new SQLiteCommand(q, con);
            command.ExecuteNonQuery();
            SQLiteDataReader dr = command.ExecuteReader();


            while (dr.Read())
            {

                for (int ii = 0; ii < 11; ii++)
                {
                    if (dr.IsDBNull(ii) == false)
                    {
                        switch (ii)
                        {
                            case 0:
                                //Name
                                newRace.Name = dr.GetString(ii);
                                break;
                            case 1:
                                //Ability Bonus
                                newRace.AbiBonus = dr.GetString(ii);
                                newRace.ConvertedBonuses = DBConverter.ConvertToViewModel(dr.GetString(ii));
                                break;
                            case 2:
                                //Size
                                newRace.Size = dr.GetString(ii);
                                break;
                            case 3:
                                //Speed
                                newRace.Speed = dr.GetInt32(ii);
                                break;
                            case 4:
                                //Darkvision
                                newRace.Darkvision = dr.GetString(ii);
                                break;
                            case 5:
                                //WEAPON Proficiencies
                                if (dr.GetInt64(ii) == 0)
                                {
                                    newRace.WeaponProficiencies.Add(new EnumBase(WeaponProficiency.None));
                                }
                                WeaponProficiency allWP = (WeaponProficiency)dr.GetInt64(ii);
                                foreach (WeaponProficiency wp in allWP.GetUniqueFlags())
                                {
                                    newRace.WeaponProficiencies.Add(new EnumBase(wp));
                                }

                                break;
                            case 6:
                                //TOOL Proficiencies
                                if (dr.GetInt64(ii) == 0)
                                {
                                    newRace.ToolProficiencies.Add(new EnumBase(ToolProficiency.None));
                                }
                                ToolProficiency allTP = (ToolProficiency) dr.GetInt64(ii);
                                foreach (ToolProficiency tp in allTP.GetUniqueFlags())
                                {
                                    newRace.ToolProficiencies.Add(new EnumBase(tp));
                                }
                                break;
                            case 7:
                                //Languages
                                if (dr.GetInt32(ii) == 0) newRace.Languages.Add(new EnumBase(Language.None));
                                Language allLang = (Language)dr.GetInt32(ii);
                                foreach (Language l in allLang.GetUniqueFlags())
                                    newRace.Languages.Add(new EnumBase(l));
                                break;
                            case 8:
                                //Parent Race
                                newRace.ParentRace = dr.GetString(ii);
                                break;
                            case 9:
                                //Skill Proficiencies
                                if (dr.GetInt32(ii) == 0) newRace.SkillProficiencies.Add(new EnumBase(SkillProficiency.None));
                                SkillProficiency allSkill = (SkillProficiency)dr.GetInt32(ii);
                                foreach (SkillProficiency cs in allSkill.GetUniqueFlags()) newRace.SkillProficiencies.Add(new EnumBase(cs));
                                break;
                            case 10:
                                //Armor Proficiencies
                                if (dr.GetInt32(ii) == 0) newRace.ArmorProficiencies.Add(new EnumBase(ArmorProficiency.None));
                                ArmorProficiency allAP = (ArmorProficiency)dr.GetInt32(ii);
                                foreach (ArmorProficiency ap in allAP.GetUniqueFlags()) newRace.ArmorProficiencies.Add(new EnumBase(ap));
                                break;
                        }

                    }
                }
            }
            dr.Close();

            if (newRace.Name != newRace.ParentRace)
            {
                string mainraceQuery = String.Format("SELECT * FROM RacialTraits WHERE Race = '{0}'", newRace.ParentRace);
                SQLiteCommand mainRaceCommand = new SQLiteCommand(mainraceQuery, con);
                mainRaceCommand.ExecuteNonQuery();
                SQLiteDataReader mainRaceDR = mainRaceCommand.ExecuteReader();

                while (mainRaceDR.Read())
                {
                    newRace.RacialTraits.Add(new Feature
                    {
                        Name = mainRaceDR.GetString(1),
                        Explanation = mainRaceDR.GetString(2)
                    });


                }
            }
            string subraceQuery = String.Format("SELECT * FROM RacialTraits WHERE Race = '{0}'", query);
            
            SQLiteCommand com = new SQLiteCommand(subraceQuery, con);
            com.ExecuteNonQuery();
            SQLiteDataReader drr = com.ExecuteReader();

            while (drr.Read())
            {
                newRace.RacialTraits.Add(new Feature
                {
                    Name = drr.GetString(1),
                    Explanation = drr.GetString(2)
                });
                    
                
            }
            return newRace;
        }


        public static ObservableCollection<Race> CreateRaceList()
        {
            ObservableCollection<Race> newRaceList = new ObservableCollection<Race>();
            string dbConnectionString = @"Data Source=FreeDataBase.sqlite;Version=3;";
            SQLiteConnection con = new SQLiteConnection(dbConnectionString);
            con.Open();
            string q = String.Format("SELECT * FROM Race");

            SQLiteCommand command = new SQLiteCommand(q, con);
            command.ExecuteNonQuery();
            SQLiteDataReader dr = command.ExecuteReader();


            while (dr.Read())
            {
                Race newRace = new Race();
                for (int ii = 0; ii < 11; ii++)
                {
                    if (dr.IsDBNull(ii) == false)
                    {
                        switch (ii)
                        {
                            case 0:
                                //Name
                                newRace.Name = dr.GetString(ii);
                                break;
                            case 1:
                                //Ability Bonus
                                newRace.AbiBonus = dr.GetString(ii);
                                newRace.ConvertedBonuses = DBConverter.ConvertToViewModel(dr.GetString(ii));
                                break;
                            case 2:
                                //Size
                                newRace.Size = dr.GetString(ii);
                                break;
                            case 3:
                                //Speed
                                newRace.Speed = dr.GetInt32(ii);
                                break;
                            case 4:
                                //Darkvision
                                newRace.Darkvision = dr.GetString(ii);
                                break;
                            case 5:
                                //WEAPON Proficiencies = MAKE CONVERTER TO PROFICIENCIES
                                if (dr.GetInt64(ii) == 0)
                                {
                                    newRace.WeaponProficiencies.Add(new EnumBase(WeaponProficiency.None));
                                }
                                WeaponProficiency allWP = (WeaponProficiency)dr.GetInt64(ii);
                                foreach (WeaponProficiency wp in allWP.GetUniqueFlags())
                                {
                                    newRace.WeaponProficiencies.Add(new EnumBase(wp));
                                }

                                break;
                            case 6:
                                //TOOL Proficiencies
                                if (dr.GetInt64(ii) == 0)
                                {
                                    newRace.ToolProficiencies.Add(new EnumBase(ToolProficiency.None));
                                }
                                ToolProficiency allTP = (ToolProficiency)dr.GetInt64(ii);
                                foreach (ToolProficiency tp in allTP.GetUniqueFlags())
                                {
                                    newRace.ToolProficiencies.Add(new EnumBase(tp));
                                }
                                break;
                            case 7:
                                //Languages
                                if (dr.GetInt32(ii) == 0) newRace.Languages.Add(new EnumBase(Language.None));
                                Language allLang = (Language)dr.GetInt32(ii);
                                foreach (Language l in allLang.GetUniqueFlags())
                                    newRace.Languages.Add(new EnumBase(l));
                                break;
                            case 8:
                                //Parent Race
                                newRace.ParentRace = dr.GetString(ii);
                                break;
                            case 9:
                                //Skill Proficiencies
                                if (dr.GetInt32(ii) == 0) newRace.SkillProficiencies.Add(new EnumBase(SkillProficiency.None));
                                SkillProficiency allSkill = (SkillProficiency)dr.GetInt32(ii);
                                foreach (SkillProficiency cs in allSkill.GetUniqueFlags()) newRace.SkillProficiencies.Add(new EnumBase(cs));

                                if (newRace.Name != newRace.ParentRace)
                                {
                                    string mainraceQuery = String.Format("SELECT * FROM RacialTraits WHERE Race = '{0}'", newRace.ParentRace);
                                    SQLiteCommand mainRaceCommand = new SQLiteCommand(mainraceQuery, con);
                                    mainRaceCommand.ExecuteNonQuery();
                                    SQLiteDataReader mainRaceDR = mainRaceCommand.ExecuteReader();

                                    while (mainRaceDR.Read())
                                    {
                                        newRace.RacialTraits.Add(new Feature
                                        {
                                            Name = mainRaceDR.GetString(1),
                                            Explanation = mainRaceDR.GetString(2)
                                        });


                                    }
                                }
                                break;
                            case 10:
                                //Armor Proficiencies
                                if (dr.GetInt32(ii) == 0) newRace.ArmorProficiencies.Add(new EnumBase(ArmorProficiency.None));
                                ArmorProficiency allAP = (ArmorProficiency)dr.GetInt32(ii);
                                foreach (ArmorProficiency ap in allAP.GetUniqueFlags()) newRace.ArmorProficiencies.Add(new EnumBase(ap));
                                break;
                        }

                    }
                }
                newRaceList.Add(newRace);
            }
            dr.Close();
            return newRaceList;
            //if (newRace.Name != newRace.ParentRace)
            //{
            //    string mainraceQuery = String.Format("SELECT * FROM RacialTraits WHERE Race = '{0}'", newRace.ParentRace);
            //    SQLiteCommand mainRaceCommand = new SQLiteCommand(mainraceQuery, con);
            //    mainRaceCommand.ExecuteNonQuery();
            //    SQLiteDataReader mainRaceDR = mainRaceCommand.ExecuteReader();

            //    while (mainRaceDR.Read())
            //    {
            //        newRace.RacialTraits.Add(new Feature
            //        {
            //            Name = mainRaceDR.GetString(1),
            //            Explanation = mainRaceDR.GetString(2)
            //        });


            //    }
            //}
            //string subraceQuery = String.Format("SELECT * FROM RacialTraits WHERE Race = '{0}'", query);

            //SQLiteCommand com = new SQLiteCommand(subraceQuery, con);
            //com.ExecuteNonQuery();
            //SQLiteDataReader drr = com.ExecuteReader();

            //while (drr.Read())
            //{
            //    newRace.RacialTraits.Add(new Feature
            //    {
            //        Name = drr.GetString(1),
            //        Explanation = drr.GetString(2)
            //    });


            //}
            //return newRace;
        }
        public static ObservableCollection<Race> CreateParentRaceList()
        {
            ObservableCollection<Race> newRaceList = new ObservableCollection<Race>();
            newRaceList.Add(None);
            string dbConnectionString = @"Data Source=FreeDataBase.sqlite;Version=3;";
            SQLiteConnection con = new SQLiteConnection(dbConnectionString);
            con.Open();
            string q = "SELECT * FROM ParentRace";

            SQLiteCommand command = new SQLiteCommand(q, con);
            command.ExecuteNonQuery();
            SQLiteDataReader dr = command.ExecuteReader();


            while (dr.Read())
            {
                Race newRace = new Race();
                for (int ii = 0; ii < 11; ii++)
                {
                    if (dr.IsDBNull(ii) == false)
                    {
                        switch (ii)
                        {
                            case 0:
                                //Name
                                newRace.Name = dr.GetString(ii);
                                break;
                            case 1:
                                //Ability Bonus
                                newRace.AbiBonus = dr.GetString(ii);
                                newRace.ConvertedBonuses = DBConverter.ConvertToViewModel(dr.GetString(ii));
                                break;
                            case 2:
                                //Size
                                newRace.Size = dr.GetString(ii);
                                break;
                            case 3:
                                //Speed
                                newRace.Speed = dr.GetInt32(ii);
                                break;
                            case 4:
                                //Darkvision
                                newRace.Darkvision = dr.GetString(ii);
                                break;
                            case 5:
                                //WEAPON Proficiencies = MAKE CONVERTER TO PROFICIENCIES
                                if (dr.GetInt64(ii) == 0)
                                {
                                    newRace.WeaponProficiencies.Add(new EnumBase(WeaponProficiency.None));
                                }
                                WeaponProficiency allWP = (WeaponProficiency)dr.GetInt64(ii);
                                foreach (WeaponProficiency wp in allWP.GetUniqueFlags())
                                {
                                    newRace.WeaponProficiencies.Add(new EnumBase(wp));
                                }

                                break;
                            case 6:
                                //TOOL Proficiencies
                                if (dr.GetInt64(ii) == 0)
                                {
                                    newRace.ToolProficiencies.Add(new EnumBase(ToolProficiency.None));
                                }
                                ToolProficiency allTP = (ToolProficiency)dr.GetInt64(ii);
                                foreach (ToolProficiency tp in allTP.GetUniqueFlags())
                                {
                                    newRace.ToolProficiencies.Add(new EnumBase(tp));
                                }
                                break;
                            case 7:
                                //Languages
                                if (dr.GetInt32(ii) == 0) newRace.Languages.Add(new EnumBase(Language.None));
                                Language allLang = (Language)dr.GetInt32(ii);
                                foreach (Language l in allLang.GetUniqueFlags())
                                    newRace.Languages.Add(new EnumBase(l));
                                break;
                            case 8:
                                //Parent Race
                                newRace.ParentRace = dr.GetString(ii);
                                break;
                            case 9:
                                //Skill Proficiencies
                                if (dr.GetInt32(ii) == 0) newRace.SkillProficiencies.Add(new EnumBase(SkillProficiency.None));
                                SkillProficiency allSkill = (SkillProficiency)dr.GetInt32(ii);
                                foreach (SkillProficiency cs in allSkill.GetUniqueFlags()) newRace.SkillProficiencies.Add(new EnumBase(cs));

                                if (newRace.Name != newRace.ParentRace)
                                {
                                    string mainraceQuery = String.Format("SELECT * FROM RacialTraits WHERE Race = '{0}'", newRace.ParentRace);
                                    SQLiteCommand mainRaceCommand = new SQLiteCommand(mainraceQuery, con);
                                    mainRaceCommand.ExecuteNonQuery();
                                    SQLiteDataReader mainRaceDR = mainRaceCommand.ExecuteReader();

                                    while (mainRaceDR.Read())
                                    {
                                        newRace.RacialTraits.Add(new Feature
                                        {
                                            Name = mainRaceDR.GetString(1),
                                            Explanation = mainRaceDR.GetString(2)
                                        });


                                    }
                                }
                                break;
                            case 10:
                                //Armor Proficiencies
                                if (dr.GetInt32(ii) == 0) newRace.ArmorProficiencies.Add(new EnumBase(ArmorProficiency.None));
                                ArmorProficiency allAP = (ArmorProficiency)dr.GetInt32(ii);
                                foreach (ArmorProficiency ap in allAP.GetUniqueFlags()) newRace.ArmorProficiencies.Add(new EnumBase(ap));
                                break;
                        }

                    }
                }
                newRaceList.Add(newRace);
            }
            dr.Close();
            return newRaceList;

        }


    }
}
