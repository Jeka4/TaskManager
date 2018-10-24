using System;
using System.Collections.Generic;

namespace TaskManager.Views
{
    public interface IMainWindow
    {
        bool TaskSelected { get; }
        DateTime DateSelected { get; }
        void Show();
        void SetUserTasksToTasksList(List<UserTaskView> tasks);
        void EnableEditRemoveControls(bool enable);
        event EventHandler<UserTaskEventArgs> UserTaskUpdated;
        event EventHandler<UserTaskEventArgs> UserTaskAdded;
        event EventHandler<UserTaskEventArgs> UserTaskDeleted;
        event EventHandler<TaskDateEventArg> CurrentCalendarDateChanged;
        event EventHandler SelectionListUpdated;
    }
}
