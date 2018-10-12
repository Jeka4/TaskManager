using System;
using System.Collections.Generic;
using TaskManager.Presenters;

namespace TaskManager.Views
{
    public interface IMainWindow
    {
        bool TaskSelected { get; }
        void Show();
        void SetUserTasksToTasksList(List<UserTaskView> tasks);
        void EnableEditRemoveControls(bool enable);
        event EventHandler<UserTaskEventArgs> UserTaskUpdated;
        event EventHandler<TaskDateEventArg> CurrentCalendarDateChanged;
        event EventHandler SelectionListUpdated;
    }
}
