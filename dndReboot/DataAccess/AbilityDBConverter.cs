using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using dndReboot.Model;
using dndReboot.Utilities;
using dndReboot.ViewModel;

namespace dndReboot.DataAccess
{
    public static class AbilityDBConverter 
    {
        public static ObservableCollection<string> ConvertFromDB(string input)
        {
            ObservableCollection<string> stringList = new ObservableCollection<string>();
            StringBuilder sb = new StringBuilder();
            for (int ii = 0; ii < input.Length; ii++)
            {
                if (input[ii] == 's')sb.Append("Strength");
                if (input[ii] == 'd')sb.Append("Dexterity");
                if (input[ii] == 'c')sb.Append("Constitution");
                if (input[ii] == 'i')sb.Append("Intelligence");
                if (input[ii] == 'w')sb.Append("Wisdom");
                if (input[ii] == 'h')sb.Append("Charisma");
                if (input[ii] == 'a')sb.Append("All");
                if (input[ii] == '+' ||
                    input[ii] ==  '-' ||
                    input[ii] ==  '1' ||
                    input[ii] ==  '2' ||
                    input[ii] ==  '3' ||
                    input[ii] ==  '4' ||
                    input[ii] ==  '5' ||
                    input[ii] ==  '6' ||
                    input[ii] ==  '7' ||
                    input[ii] ==  '8' ||
                    input[ii] ==  '9' 
                    ) sb.Append(input[ii]);
                if (input[ii] == ',')
                {
                    stringList.Add(sb.ToString());
                }                
            }

            return stringList;
        }

        public static ObservableCollection<AbilityBonusViewModel> ConvertToVM(string input)
        {
            ObservableCollection<AbilityBonusViewModel> output = new ObservableCollection<AbilityBonusViewModel>();

            string s = string.Empty;
            int x = 0;
            for (int ii = 0; ii < input.Length; ii++)
            {
                if (input[ii] == 's')
                {
                    s = "Strength";
                }
                if (input[ii] == 'd')
                {
                    s = "Dexterity";
                }
                if (input[ii] == 'c')
                {
                    s = "Constitution";
                }
                if (input[ii] == 'i') s = "Intelligence";
                if (input[ii] == 'w') s = "Wisdom";
                if (input[ii] == 'h') s = "Charisma";
                if (input[ii] == 'a') s = "All";
                if (input[ii] == '+')
                {
                    x = int.Parse(input[ii + 1].ToString());
                }
                if (input[ii] == '-')
                {
                    x = int.Parse((input[ii + 1].ToString())) * -1;
                }
                if (input[ii] == ',')
                {
                    output.Add(new AbilityBonusViewModel(s,x));
                }
            }


            return output;
        }



        public static string ConvertToDB(ObservableCollection<AbilityBonusViewModel> abilityBonuses)
        {
            StringBuilder output = new StringBuilder();

            foreach (AbilityBonusViewModel abvm in abilityBonuses)
            {
                if(!abvm.SelectedAbility.Description.StartsWith("Charisma"))
                    output.Append(abvm.SelectedAbility.Description.ToLower()[0]);
                else if (abvm.SelectedAbility.Description.StartsWith("Charisma"))
                {
                    output.Append('h');
                }
                if (!abvm.SelectedBonus.ToString().Contains('-')) output.Append('+');
                output.Append(abvm.SelectedBonus.ToString());
                output.Append(',');
            }
            return output.ToString();
        }
    }
}
