using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace ConvertersInWPF.Converters
{
    public class StatusToColor: IValueConverter
    {

        public enum Status
        {
            Submitted,
            Assigned,
            InProgress,
            Resolved,
            Closed
        }

        #region IValueConverter Members

        public object Convert(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            Request.Status state = (Request.Status)value;
            Status stateColor = (Status)Enum.Parse(typeof(Status), value.ToString());

            switch (state)
            {
                case Request.Status.Submitted:
                    if (stateColor == Status.Submitted)
                    { return new SolidColorBrush(Colors.Red); }
                    break;
                case Request.Status.Assigned:
                    if (stateColor == Status.Assigned)
                    { return new SolidColorBrush(Colors.Orange); }
                    break;
                case Request.Status.InProgress:
                    if (stateColor == Status.InProgress)
                    { return new SolidColorBrush(Colors.Gold); }
                    break;
                case Request.Status.Resolved:
                    if (stateColor == Status.Resolved)
                    { return new SolidColorBrush(Colors.YellowGreen); }
                    break;
                case Request.Status.Closed:
                    if (stateColor == Status.Closed)
                    { return new SolidColorBrush(Colors.Gray); }
                    break;
            }
            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
