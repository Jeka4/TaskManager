using System;
using System.Globalization;
using System.Windows.Data;

namespace TaskManagerView.Components
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
            if (!(parameter is Type)) return null;
            foreach (var one in Enum.GetValues(parameter as Type))
            {
                if (value.ToString() == (one as Enum).GetDescription())
                    return one;
            }
            return null;
        }
    }
}
