using System;
using System.Collections.Generic;
using TaskManager.ViewComponents;
using TaskManager.Views;

namespace TaskManager.Presenters
{
    public interface ITaskManagerPresenter
    {
        void AddTask(UserTaskView task);
        void RemoveTask(UserTaskView task);
        void EditTask(UserTaskView task);
        void RefreshViewTasksList(DateTime day);
        List<UserTaskView> LoadTasksOfDay(DateTime day);
        List<UserTaskView> LoadAllTasks();
    }
}
