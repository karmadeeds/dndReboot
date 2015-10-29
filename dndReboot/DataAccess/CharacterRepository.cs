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

namespace dndReboot.DataAccess
{
    public class CharacterRepository
    {
        readonly List<Character> _characters;

        public CharacterRepository()
        {
            if (_characters == null)
            {
                _characters = new List<Character>();
            }
            _characters.Add(new Character());

        }

        public event EventHandler<CharacterAddedEventArgs> CharacterAdded;

        public void AddCharacter(Character character)
        {
            if (character == null) throw new ArgumentNullException("character");

            if (!_characters.Contains(character))
            {
                _characters.Add(character);
                if (this.CharacterAdded != null)
                    this.CharacterAdded(this, new CharacterAddedEventArgs(character));
            }
        }

        public bool ContainsCharacter(Character character)
        {
            if (character == null)
                throw new ArgumentNullException("character");
            return _characters.Contains(character);
        }

        public bool ContainsAny()
        {
            if (_characters.Count > 0) return true;
            else return false;
        }

        public List<Character> GetCharacters()
        {
            return new List<Character>(_characters);
        }

        //static List<Character> LoadCharacters(string characterDataFile)
        //{
        //    using (Stream stream = GetResourceStream(characterDataFile))
        //    using (XmlReader xmlRdr = new XmlTextReader(stream))
        //        return
        //            (from characterElem in XDocument.Load(xmlRdr).Element("characters").Elements("character")
        //             select Character.CreateCharacter(
        //             (string)characterElem.Attribute("name"),
        //             new ObservableCollection<AbiBonus>(),
        //             (string)characterElem.Attribute("speed"),
        //             (string)characterElem.Attribute("size"),
        //             (string)characterElem.Attribute("darkvision"),
        //             new ObservableCollection<Proficiency>()
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
