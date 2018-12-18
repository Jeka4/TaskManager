using System;
using System.Windows.Markup;

namespace TaskManagerView.Components
{
    class BoolToListSource : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new []
            {
                "Нет",
                "Да"
            };
        }
    }
}
