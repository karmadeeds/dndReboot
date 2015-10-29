using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace dndReboot.Utilities
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType == typeof (Visibility))
            {
                bool visible = System.Convert.ToBoolean(value, culture);
                if (InvertVisibility) visible = !visible;
                return visible ? Visibility.Visible : Visibility.Collapsed;
            }
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public Boolean InvertVisibility { get; set; }
    }
}
