using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using dndReboot.Model;
using dndReboot.View;
using dndReboot.ViewModel;

namespace dndReboot.Utilities
{
    public static class DBConverter
    {
        //private static string highelf = "c+2,w+1";

        public static ObservableCollection<string> ConvertToViewModel(string dbString)
        {
            ObservableCollection<string> bar = new ObservableCollection<string>();
            int abilitySplit = dbString.IndexOf(',');
            char[] c = dbString.ToCharArray();
            bar.Add(ConvertDBString(c,0,abilitySplit));
            if (c.Length > 4 && c.Length < 9) bar.Add(ConvertDBString(c, 4, 7));
            if (c.Length > 8)
            {
                //MessageBox.Show(c.Length.ToString());
                //foreach (var ss in c)
                //{
                //    MessageBox.Show("Char =" + ss + "Index = " + dbString.IndexOf(ss));
                //}
                bar.Add(ConvertDBString(c,4, 7));
                bar.Add(ConvertDBString(c, 8, 11));
            }
            return bar;
        }

        public static AbilityBonusViewModel ConvertToAbilityBonusView(string dbString)
        {
            string s = string.Empty;
            int x = -1;
            int v = 0;
            //AbilityBonusViewModel abvm = new AbilityBonusViewModel();
            if (dbString.Length == 4)
            {

                char c = dbString[0];
                switch (c)
                {
                    case 's':
                        s = "Strength";
                        x = 0;
                        break;
                    case 'd':
                        s = "Dexterity";
                        x = 1;
                        break;
                    case 'c':
                        s = "Constitution";
                        x = 2;
                        break;
                    case 'i':
                        s = "Intelligence";
                        x = 3;
                        break;
                    case 'w':
                        s = "Wisdom";
                        x = 4;
                        break;
                    case 'h':
                        s = "Charisma";
                        x = 5;
                        break;
                    case 'a':
                        s = "All";
                        x = 6;
                        break;
                }
                v = Int32.Parse(dbString[2].ToString());
                if (dbString[1] == '-') v = v*-1;
                //AbilityBonusViewModel abvm = new AbilityBonusViewModel(x, v);
            }
            return new AbilityBonusViewModel(x, v);
        }


        public static void CountCharsInString(string dbString, char c)
        {
            int num = dbString.Count(x => x == c);
            MessageBox.Show(num.ToString());
        }

        //public string CharacterToString()


        public static string ConvertDBString(char[] c, int startIndex, int endIndex)
        {

            StringBuilder temp = new StringBuilder();

            string x;
            char y;
            int z;
            

            switch (c[startIndex])
            {
                case 's':
                    x = "Strength";
                    break;
                case 'd':
                    x = "Dexterity";
                    break;
                case 'c':
                    x = "Constitution";
                    break;
                case 'i':
                    x = "Intelligence";
                    break;
                case 'w':
                    x = "Wisdom";
                    break;
                case 'h':
                    x = "Charisma";
                    break;
                case 'a':
                    x = "All";
                    break;
                default:
                    x = String.Empty;
                    break;
            }

            switch (c[startIndex + 1])
            {
                case '+':
                    y = '+';
                    break;
                case '-':
                    y = '-';
                    break;
                default:
                    y = '#';
                    break;
            }
            z = (int) Char.GetNumericValue(c[endIndex - 1]);

            string bar = String.Format("{0} {1} {2}", x, y, z);
            return bar;
        }
        // idea:
        // Convert a string such as "d+2,i+1" into a method that 

        public static dynamic ConvertEnumBaseToBaseType(ObservableCollection<EnumBase> ProficiencyList)
        {
            var EnumType = Enum.GetUnderlyingType(ProficiencyList[0].Value.GetType());

            //MessageBox.Show(EnumType.ToString());

            if (EnumType == typeof (long))
            {
                //MessageBox.Show(ProficiencyList[0].ToString()+"ulong");
                List<long> tempList = new List<long>();
                foreach (EnumBase eb in ProficiencyList)
                {
                    tempList.Add(Convert.ToInt64(eb.Value));
                }
                long foo = 0;
                for (int ii = 0; ii < tempList.Count; ii++)
                {
                    foo += tempList[ii];
                }

                return foo;
            }
            else if (EnumType == typeof (int))
            {
                //MessageBox.Show(ProficiencyList[0].ToString() + "int");
                List<int> tempList = new List<int>();
                foreach (EnumBase eb in ProficiencyList)
                {
                    tempList.Add(Convert.ToInt32(eb.Value));
                }
                int foo = 0;
                for (int ii = 0; ii < tempList.Count; ii++)
                {
                    foo += tempList[ii];
                }
                return foo;
            }

            else
            {
                //MessageBox.Show(ProficiencyList[0].ToString() + "neither");
                //MessageBox.Show(EnumType.ToString());
                return EnumType;
            }
        }
    }
}
