using TaskManagerCommon.Components;

namespace TaskManagerView.Components
{
    public class TaskListSettings : ITaskListSettings
    {
        public FilterType Filter { get; set; }

        public TaskListSettings(FilterType filter)
        {
            Filter = filter;
        }
    }
}
