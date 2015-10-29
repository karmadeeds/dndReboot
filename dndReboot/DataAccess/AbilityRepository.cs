using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Resources;
using System.Xml;
using System.Xml.Linq;
using dndReboot.Model;

namespace dndReboot.DataAccess
{
    public class AbilityRepository
    {
        private readonly List<Ability> _abilities;

        public AbilityRepository()
        {
            if (_abilities == null)
            {
                _abilities = new List<Ability>();
            }
            _abilities.Add(new Ability("Strength"));
            _abilities.Add(new Ability("Dexterity"));
            _abilities.Add(new Ability("Constitution"));
            _abilities.Add(new Ability("Intelligence"));
            _abilities.Add(new Ability("Wisdom"));
            _abilities.Add(new Ability("Charisma"));
        }
        public List<Ability> GetAbilities()
        {
            return new List<Ability>(_abilities);
        }


        //public List<Ability> LoadFeatures(string abilityDataFile)
        //{
        //    using (Stream stream = GetResourceStream(abilityDataFile))
        //    using (XmlReader xmlRdr = new XmlTextReader(stream))
        //        return
        //            (from abilityElem in XDocument.Load(xmlRdr).Element("abilities").Elements("ability")
        //             select Ability.CreateAbility(
        //             (string)abilityElem.Attribute("name")
        //             )).ToList();
        //}
        //static Stream GetResourceStream(string resourceFile)
        //{
        //    Uri uri = new Uri(resourceFile, UriKind.RelativeOrAbsolute);
        //    StreamResourceInfo info = Application.GetResourceStream(uri);
        //    if (info == null || info.Stream == null)
        //        throw new ApplicationException("Missing resource file: " + resourceFile);

        //    return info.Stream;
        //}

    }
}
