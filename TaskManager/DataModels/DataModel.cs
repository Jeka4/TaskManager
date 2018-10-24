using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using TaskManager.DataModelComponents;

namespace TaskManager.DataModels
{
    public class DataModel : IDataModel
    {
        public event EventHandler TasksDBUpdated = delegate { };

        private FilterType _filterType = FilterType.All;

        private SortType _sortType = SortType.AscendingPriority;

        private readonly ITaskFilter _taskFilter;

        public DataModel(ITaskFilter taskFilter)
    {
            _taskFilter = taskFilter;
        }

        public void AddTask(UserTask task)
        {
            using (var db = new UserTasksDB())
                db.Insert(task);

            TasksDBUpdated(this, new EventArgs());
        }

        public void UpdateTask(UserTask task)
        {
            using (var db = new UserTasksDB())
                db.Update(task);

            TasksDBUpdated(this, new EventArgs());
        }

        public void DeleteTask(UserTask task)
        {
            using (var db = new UserTasksDB())
                db.Delete(task);

            TasksDBUpdated(this, new EventArgs());
        }

        public List<UserTask> GetAllTasks()
        {
            List<UserTask> tasks = new List<UserTask>();
            using (var db = new UserTasksDB())
            {
                var query = from t in db.UserTasks
                            select t;

                _taskFilter.Filter(query, _filterType);

                tasks = query.ToList();
            }
            return tasks;
        }

        public List<UserTask> GetTasksOfDay(string date) //Использовать DateTime? + дублирование кода
        {
            List<UserTask> tasks = new List<UserTask>();
            using (var db = new UserTasksDB())
            {
                var query = from t in db.UserTasks
                            where t.TaskDate == date
                            select t;

                _taskFilter.Filter(query, _filterType);

                tasks = query.ToList();
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
