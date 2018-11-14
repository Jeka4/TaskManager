using System;
using System.Collections.Generic;
using TaskManager.ViewComponents;
using TaskManager.Components;

namespace TaskManager.Views
{
    public interface IMainWindow
    {
        bool TaskSelected { get; }
        DateInterval DateIntervalSelected { get; }
        ITaskListSettings TaskListSettings { get; }
        void Show();
        void ShowMessageBox(string message);
        void SetUserTasksToTasksList(List<UserTaskView> tasks);
        void SetHighlightDates(List<DateTime> dates);
        void EnableEditRemoveControls(bool enable);
        event EventHandler<UserTaskEventArgs> UserTaskUpdated;
        event EventHandler<UserTaskEventArgs> UserTaskAdded;
        event EventHandler<UserTaskEventArgs> UserTaskDeleted;
        event EventHandler<TaskDateIntervalEventArg> CurrentCalendarDateChanged;
        event EventHandler<FilterEventArgs> FilterTypeChanged;
        event EventHandler SelectionListUpdated;
    }
}
