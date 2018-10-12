using System.Collections.Generic;
using TaskManager.Presenters;

namespace TaskManager.Views
{
    public interface IMainWindow
    {
        void Show();
        void BindPresenter(ITaskManagerPresenter presenter);
        void SetUserTasksToTasksList(List<UserTaskView> tasks);
    }
}
