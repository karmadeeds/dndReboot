using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using dndReboot.Model;
using dndReboot.ViewModel;
using System.Collections.ObjectModel;

namespace dndReboot.DataAccess
{
    public class FeatureRepository
    {
        
        readonly List<Feature> _features;

        public FeatureRepository()
        {
            if (_features == null)
            {
                _features = new List<Feature>();
            }
            List<Feature> tempList = new List<Feature>();


           // MessageBox.Show(tempList.Count.ToString());
            _features = tempList;
            

        }

        public FeatureRepository(Character mC)
        {
            if (_features == null)
            {
                _features = new List<Feature>();
            }
            List<Feature> tempList = LoadFeatures(mC);
            if (tempList != null)
            {
                _features = tempList;
            }
        }

        public event EventHandler<FeatureAddedEventArgs> FeatureAdded;

        public void AddFeature(Feature feature)
        {
            if (feature == null) throw new ArgumentNullException("feature");

            if (!_features.Contains(feature))
            {
                _features.Add(feature);
                if (this.FeatureAdded != null)
                    this.FeatureAdded(this, new FeatureAddedEventArgs(feature));
            }
        }

        public bool ContainsFeature(Feature feature)
        {
            if (feature == null)
                throw new ArgumentNullException("feature");
            return _features.Contains(feature);
        }

        public List<Feature> GetFeatures()
        {
            return new List<Feature>(_features);
        }

        public List<string> ListFeaturesQuery(Character mC)
        {
            List<string> tempList = new List<string>();
            foreach (CharacterClass cc in mC.Classes)
            {
                tempList.Add("SELECT feature1, feature2, feature3 FROM '"+cc.Name+"' WHERE level BETWEEN 0 AND "+cc.Level);
            }
            return tempList;
        }

        public List<string> DetailFeaturesQuery(Character mC)
        {
            List<string> tempList = new List<string>();
            foreach (CharacterClass cc in mC.Classes)
            {
                tempList.Add("SELECT Features.* FROM "+cc.Name+" JOIN Features ON Name = "+cc.Name+".feature1 OR NAME = "+cc.Name+".feature2 OR NAME = "+cc.Name+".feature3 WHERE "+cc.Name+".level BETWEEN 0 AND "+cc.Level); 
            }
            return tempList;
        }

        public List<string> GetListTest(Character mC)
        {
            List<string> ListofStuff = new List<string>();

            

            using (SQLiteConnection con = new SQLiteConnection(@"Data Source=database.db;Version=3;"))
            {
                con.Open();
                using (SQLiteCommand fmd = con.CreateCommand())
                {
                    //Query string, need to change
                    foreach (CharacterClass cc in mC.Classes)
                    {
                        fmd.CommandText = "SELECT feature1, feature2, feature3 FROM '"+cc.Name+"' WHERE level BETWEEN 0 AND "+cc.Level;
                        fmd.CommandType = CommandType.Text;
                        SQLiteDataReader dr = fmd.ExecuteReader();
                        while (dr.Read())
                        {
                            for (int ii = 0; ii < 3; ii++)
                            {
                                if (dr.IsDBNull(ii) == false)
                                {
                                    ListofStuff.Add(dr.GetString(ii));
                                }
                            }
                        }
                        dr.Close();
                    
                    
                    //SQLiteCommand command = new SQLiteCommand(q);

                        //ListofStuff.Add(Convert.ToString(dr["feature1"]));
                        //ListofStuff.Add(Convert.ToString(dr["feature2"]));
                        //ListofStuff.Add(Convert.ToString(dr["feature3"]));
                    }
                }
            }
            return ListofStuff;
        }

        public List<Feature> LoadFeatures(Character character)
        {
            List<Feature> featureList = new List<Feature>();
            List<string> tempL = ListFeaturesQuery(character);
            using (SQLiteConnection con = new SQLiteConnection(@"Data Source=database.db;Version=3;"))
            {
                con.Open();
                using (SQLiteCommand fmd = con.CreateCommand())
                {
                    foreach (string s in tempL)
                    {
                        fmd.CommandText = s;
                        fmd.CommandType = CommandType.Text;
                        SQLiteDataReader dr = fmd.ExecuteReader();
                        while (dr.Read())
                        {
                            for (int ii = 0; ii < 3; ii++)
                            {
                                if (dr.IsDBNull(ii) == false)
                                {
                                    featureList.Add(new Feature(dr.GetString(ii)));
                                }
                            }
                        }
                        dr.Close();
                    }
                }
            }
            return featureList;
            
        }

    }
}
