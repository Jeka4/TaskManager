using System;
using System.Collections.Generic;
using TaskManagerCommon.Components;
using TaskManagerView.ViewComponents;

namespace TaskManagerPresenter.Presenters
{
    public interface ITaskManagerPresenter
    {
        void AddTask(UserTaskView task);
        void RemoveTask(UserTaskView task);
        void EditTask(UserTaskView task);
        void RefreshViewTasksList(DateInterval dateInterval);
        List<UserTaskView> LoadTasksOfDay(DateTime day);
        List<UserTaskView> LoadTasksOfDays(DateInterval dayInterval);
        List<UserTaskView> LoadAllTasks();
    }
}
