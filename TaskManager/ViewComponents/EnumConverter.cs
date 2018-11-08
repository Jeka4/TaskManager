using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.ComponentModel;

namespace TaskManager.ViewComponents
{
    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(parameter is Type)) throw new ArgumentException(nameof(parameter));
            if (value == null) return string.Empty;

            foreach (var item in Enum.GetValues(parameter as Type))
            {
                if (value.Equals(item))
                    return (item as Enum).GetDescription();
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            foreach (var one in Enum.GetValues(parameter as Type))
            {
                if (value.ToString() == (one as Enum).GetDescription())
                    return one;
            }
            return null;
        }
    }
}
