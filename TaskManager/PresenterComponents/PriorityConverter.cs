using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = TaskManager.DataModelComponents;
using view = TaskManager.Views;

namespace TaskManager.PresenterComponents
{
    public class PriorityConverter : IPriorityConverter
    {
        public string ConvertToModelPriority(view.TaskPriority priority)
        {
            switch (priority)
            {
                case view.TaskPriority.High:
                    return model.TaskPriority.High.ToString();
                case view.TaskPriority.Medium:
                    return model.TaskPriority.Medium.ToString();
                case view.TaskPriority.Low:
                    return model.TaskPriority.Low.ToString();
                default:
                    throw new ArgumentException("Unknow priority");
            }
        }

        public Views.TaskPriority ConvertToViewPriority(string priority)
        {
            model.TaskPriority modelPriority;
            bool success = Enum.TryParse(priority, out modelPriority);

            if (!success)
                throw new ArgumentException("The string is not reducible to enum.");

            switch (modelPriority)
            {
                case model.TaskPriority.High:
                    return view.TaskPriority.High;
                case model.TaskPriority.Medium:
                    return view.TaskPriority.Medium;
                case model.TaskPriority.Low:
                    return view.TaskPriority.Low;
                default:
                    throw new ArgumentException("Unknow priority");
            }
        }
    }
}
