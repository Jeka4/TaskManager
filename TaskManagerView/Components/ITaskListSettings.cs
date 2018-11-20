using TaskManagerCommon.Components;

namespace TaskManagerView.Components
{
    public interface ITaskListSettings
    {
        FilterType Filter { get; }
        SortType Sort { get; }
    }
}
