using TaskManagerCommon.Components;

namespace TaskManagerPresenter.Components
{
    public interface IPriorityConverter
    {
        string ConvertToModelPriority(TaskPriority priority);

        TaskPriority ConvertToViewPriority(string priority);
    }
}
