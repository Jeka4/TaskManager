using System;
using System.Collections.Generic;
using TaskManager.DataModelComponents;
using TaskManager.Components;

namespace TaskManager.DataModels
{
    public interface IDataModel
    {
        FilterType Filter { get; set; }
        SortType Sort { get; set; }
        void AddTask(UserTask task);
        void UpdateTask(UserTask task);
        void DeleteTask(UserTask task);
        List<UserTask> GetAllTasks();
        List<UserTask> GetTasksOfDay(string date);
        List<UserTask> GetTasksOfDays(string beginDate, string endDate);
        List<string> GetAllTaskDates();
        event EventHandler TasksDbUpdated;
    }
}
