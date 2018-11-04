using System;
using TaskManager.Components;

namespace TaskManager.PresenterComponents
{
    public class PriorityConverter : IPriorityConverter
    {
        public string ConvertToModelPriority(TaskPriority priority)
        {
            if(priority == TaskPriority.Undefined)
                throw new ArgumentException("Unknow priority");

            return priority.ToString();
        }

        public TaskPriority ConvertToViewPriority(string priority)
        {
            TaskPriority modelPriority;
            bool success = Enum.TryParse(priority, out modelPriority);

            if (!success)
                throw new ArgumentException("The string is not reducible to enum.");

            if(modelPriority == TaskPriority.Undefined)
                throw new ArgumentException("Unknow priority");

            return modelPriority;
        }
    }
}
