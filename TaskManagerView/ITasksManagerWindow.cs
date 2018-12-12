using System;
using System.Collections.Generic;
using System.Windows;
using TaskManagerView.Components;

namespace TaskManagerView
{
    public interface ITasksManagerWindow
    {
        bool IsTaskSelected { get; }
        void Initialize();
        void EnableDeleteButton(bool enable);
        void EnableDeleteCompletedAndAllButton(bool enable);
        void SetUserTasksToTasksList(List<UserTaskView> tasks);
        event EventHandler<UserTaskEventArgs> UserTaskEdited;
        event EventHandler<UserTasksListEventArgs> UserTasksDeleted;
        event EventHandler UserTasksAllDeleted;
        event EventHandler UserTasksCompletedDeleted;
        event EventHandler SelectionListChanged;
        event EventHandler TasksListNeedUpdate;
        event EventHandler Closed;
    }
}
