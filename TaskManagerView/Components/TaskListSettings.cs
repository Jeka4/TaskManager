using TaskManagerCommon.Components;

namespace TaskManagerView.Components
{
    public class TaskListSettings : ITaskListSettings
    {
        public FilterType Filter { get; set; }

        public SortType Sort { get; set; }

        public TaskListSettings(FilterType filter, SortType sort)
        {
            Filter = filter;
            Sort = sort;
        }
    }
}
