using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace TaskManager.DataModels
{
    public interface IDataModel
    {
        void AddTask(UserTask task);
        void UpdateTask(UserTask task);
        void DeleteTask(UserTask task);
        List<UserTask> GetAllTasks();
        List<UserTask> GetTasksOfDay(string date);
        void SortBy(SortType sort);
        void FilterBy(FilterType filter);
        event EventHandler TasksDBUpdated;
    }
}
