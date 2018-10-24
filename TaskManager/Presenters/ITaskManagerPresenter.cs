using System;
using System.Collections.Generic;
using TaskManager.Views;

namespace TaskManager.Presenters
{
    public interface ITaskManagerPresenter
    {
        void AddTask(UserTaskView task);
        void RemoveTask(UserTaskView task);
        void EditTask(UserTaskView task);
        List<UserTaskView> LoadTasksOfDay(DateTime day);
        List<UserTaskView> LoadAllTasks();
    }
}
