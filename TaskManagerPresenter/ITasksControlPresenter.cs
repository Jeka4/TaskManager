using System;
using TaskManagerView.Components;

namespace TaskManagerPresenter
{
    public interface ITasksControlPresenter
    {
        void Initialize();
        void ShowTasksControlWindow();
        void RefreshTasksList();
        event EventHandler<UserTaskEventArgs> UserTaskUpdated;
    }
}