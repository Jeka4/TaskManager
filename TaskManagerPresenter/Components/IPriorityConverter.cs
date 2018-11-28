using TaskManagerCommon.Components;

namespace TaskManagerPresenter.Components
{
    public interface IPriorityConverter
    {
        long ConvertToModelPriority(TaskPriority priority);

        TaskPriority ConvertToViewPriority(long priority);
    }
}
