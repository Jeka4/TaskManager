using System;
using System.Collections.Generic;
using System.Windows;
using TaskManagerView.Components;

namespace TaskManagerView
{
    public interface ITasksManagerWindow
    {
        void Initialize();
        void SetUserTasksToTasksList(List<UserTaskView> tasks);
        event EventHandler TasksListNeedUpdate;
        event EventHandler Closed;
    }
}
