using TaskManager.Components;

namespace TaskManager.PresenterComponents
{
    public interface IPriorityConverter
    {
        string ConvertToModelPriority(TaskPriority priority);

        TaskPriority ConvertToViewPriority(string priority);
    }
}
