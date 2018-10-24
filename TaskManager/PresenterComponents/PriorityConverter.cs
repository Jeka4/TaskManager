using System;
using TaskManager.Components;

namespace TaskManager.PresenterComponents
{
    public class PriorityConverter : IPriorityConverter
    {
        public string ConvertToModelPriority(TaskPriority priority)
        {
            switch (priority)
            {
                case TaskPriority.High:
                    return TaskPriority.High.ToString();
                case TaskPriority.Medium:
                    return TaskPriority.Medium.ToString();
                case TaskPriority.Low:
                    return TaskPriority.Low.ToString();
                default:
                    throw new ArgumentException("Unknow priority");
            }
        }

        public TaskPriority ConvertToViewPriority(string priority)
        {
            TaskPriority modelPriority;
            bool success = Enum.TryParse(priority, out modelPriority);

            if (!success)
                throw new ArgumentException("The string is not reducible to enum.");

            switch (modelPriority)
            {
                case TaskPriority.High:
                    return TaskPriority.High;
                case TaskPriority.Medium:
                    return TaskPriority.Medium;
                case TaskPriority.Low:
                    return TaskPriority.Low;
                default:
                    throw new ArgumentException("Unknow priority");
            }
        }
    }
}
