using System;
using TaskManagerCommon.Components;

namespace TaskManagerPresenter.Components
{
    public class PriorityConverter : IPriorityConverter
    {
        public long ConvertToModelPriority(TaskPriority priority)
        {
            if(priority == TaskPriority.Undefined)
                throw new ArgumentException("Unknow priority");

            return (long)priority;
        }

        public TaskPriority ConvertToViewPriority(long priority)
        {
            TaskPriority modelPriority;
            bool success = Enum.TryParse(priority.ToString(), out modelPriority);

            if (!success)
                throw new ArgumentException("The string is not reducible to enum.");

            if(modelPriority == TaskPriority.Undefined)
                throw new ArgumentException("Unknow priority");

            return modelPriority;
        }
    }
}
