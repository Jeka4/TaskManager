using System;
using System.Collections.Generic;
using TaskManagerCommon.Components;
using TaskManagerModel.Components;

namespace TaskManagerModel
{
    public interface IDataModel
    {
        FilterType Filter { get; set; }
        SortType Sort { get; set; }
        void AddTask(UserTask task);
        void UpdateTask(UserTask task);
        void DeleteTask(UserTask task);
        void DeleteTasks(List<UserTask> tasksList);
        List<UserTask> GetAllTasks();
        List<UserTask> GetTasksOfDay(DateTime date);
        List<UserTask> GetTasksOfDays(DateTime beginDate, DateTime endDate);
        List<DateTime> GetAllTaskDates();
        event EventHandler TasksDbUpdated;
    }
}
