using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Markup;

namespace TaskManagerView.ViewComponents
{
    public class EnumToListSource : MarkupExtension
    {
        private readonly Type _type;

        public EnumToListSource(Type type)
        {
            _type = type;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _type.GetFields().SelectMany(member => member.GetCustomAttributes(typeof(DescriptionAttribute), true)
                                                                 .Cast<DescriptionAttribute>())
                                                                 .Skip(1)
                                                                 .Select(x => x.Description)
                                                                 .ToList();
        }
    }
}
