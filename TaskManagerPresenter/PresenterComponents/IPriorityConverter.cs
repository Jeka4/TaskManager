using TaskManagerCommon.Components;

namespace TaskManagerPresenter.PresenterComponents
{
    public interface IPriorityConverter
    {
        string ConvertToModelPriority(TaskPriority priority);

        TaskPriority ConvertToViewPriority(string priority);
    }
}
