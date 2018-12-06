using System;
using System.Collections.Generic;
using TaskManagerCommon.Components;
using TaskManagerView.Components;

namespace TaskManagerView
{
    public interface IMainWindow
    {
        void Initialize();
        bool TaskSelected { get; }
        DateInterval DateIntervalSelected { get; }
        ITaskListSettings TaskListSettings { get; }
        void ShowMessageBox(string message);
        void SetUserTasksToTasksList(List<UserTaskView> tasks);
        void SetHighlightDates(List<DateTime> dates);
        void EnableEditRemoveControls(bool enable);
        event EventHandler<UserTaskEventArgs> UserTaskUpdated;
        event EventHandler<UserTaskEventArgs> UserTaskAdded;
        event EventHandler<UserTaskEventArgs> UserTaskDeleted;
        event EventHandler<TaskDateIntervalEventArg> CurrentCalendarDateChanged;
        event EventHandler<FilterEventArgs> FilterTypeChanged;
        event EventHandler<SortEventArgs> SortTypeChanged;
        event EventHandler TasksControlButtonPressed;
        event EventHandler SelectionListUpdated;
        event EventHandler TasksListNeedUpdate;
        event EventHandler HighlightListNeedUpdate;
    }
}
