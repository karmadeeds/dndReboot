using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using dndReboot.Model;
using dndReboot.ViewModel;

namespace dndReboot.Utilities
{
    public class RaceSelectionToIsCheckedConverter :IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string test = value as string;
            if (test == "Human")
            {
                return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public Boolean InvertChecked { get; set; }
    }
}
