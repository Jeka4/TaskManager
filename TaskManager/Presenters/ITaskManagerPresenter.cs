using System;
using System.Collections.Generic;
using TaskManager.Views;

namespace TaskManager.Presenters
{
    public interface ITaskManagerPresenter //Заглушки
    {
        void AddTask(UserTaskView task);
        void RemoveTask(int id);
        void EditTask(UserTaskView task);
        List<UserTaskView> LoadTasksOfDay(DateTime day);
        List<UserTaskView> LoadAllTasks();
    }
}
