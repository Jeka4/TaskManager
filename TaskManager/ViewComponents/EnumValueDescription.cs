using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ViewComponents
{
    public static class EnumValueDescription
    {
        public static string GetDescription(this Enum enumVal)
        {
            Type enumType = enumVal.GetType();
            Array enumValues = Enum.GetValues(enumType);

            foreach (var value in enumValues)
            {
                if(value.Equals(enumVal))
                {
                    var fieldsInfo = enumType.GetField(enumType.GetEnumName(value));
                    var descriptionAttribute = fieldsInfo
                        .GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .FirstOrDefault() as DescriptionAttribute;

                    if (descriptionAttribute != null)
                        return descriptionAttribute.Description;
                }
            }

            return null;
        }
    }
}
