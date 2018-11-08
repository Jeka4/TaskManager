using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using TaskManager.DataModelComponents;
using TaskManager.Components;

namespace TaskManager.DataModels
{
    public class DataModel : IDataModel
    {
        public event EventHandler TasksDbUpdated = delegate { };

        private FilterType _filterType;

        private SortType _sortType;

        private readonly ITaskFilter _taskFilter;

        public DataModel(ITaskFilter taskFilter)
        {
            _taskFilter = taskFilter;
            _filterType = FilterType.All;
            _sortType = SortType.AscendingPriority;
        }

        public void AddTask(UserTask task)
        {
            using (var db = new UserTasksDB())
                db.Insert(task);

            TasksDbUpdated(this, new EventArgs());
        }

        public void UpdateTask(UserTask task)
        {
            using (var db = new UserTasksDB())
                db.Update(task);

            TasksDbUpdated(this, new EventArgs());
        }

        public void DeleteTask(UserTask task)
        {
            using (var db = new UserTasksDB())
                db.Delete(task);

            TasksDbUpdated(this, new EventArgs());
        }

        public List<UserTask> GetAllTasks()
        {
            List<UserTask> tasks;
            using (var db = new UserTasksDB())
            {
                var query = db.UserTasks;
                var filterResult = _taskFilter.Filter(query, _filterType);

                tasks = filterResult.ToList();
            }
            return tasks;
        }

        public List<UserTask> GetTasksOfDay(string date)
        {
            List<UserTask> tasks;
            using (var db = new UserTasksDB())
            {
                var query = db.UserTasks.Where(t => t.TaskDate == date);
                var filterResult = _taskFilter.Filter(query, _filterType);

                tasks = filterResult.ToList();
            }
            return tasks;
        }

        public List<UserTask> GetTasksOfDays(string beginDate, string endDate)
        {
            List<UserTask> tasks;
            using (var db = new UserTasksDB())
            {
                var query = db.UserTasks.Where(t => t.TaskDate.CompareTo(beginDate) >= 0 && t.TaskDate.CompareTo(endDate) <= 0);
                var filterResult = _taskFilter.Filter(query, _filterType);

                tasks = filterResult.ToList();
            }
            return tasks;
        }

        public void SortBy(SortType sort)
        {
            throw new NotImplementedException();
        }

        public void FilterBy(FilterType filter)
        {
            _filterType = filter;
        }
    }
}
