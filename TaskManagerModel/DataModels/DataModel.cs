using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqToDB;
using TaskManagerCommon.Components;
using TaskManagerModel.DataModelComponents;

namespace TaskManagerModel.DataModels
{
    public class DataModel : IDataModel
    {
        public event EventHandler TasksDbUpdated = delegate { };

        public FilterType Filter
        {
            get
            {
                return _filterType;
            }
            set
            {
                _filterType = value;
            }
        }   

        public SortType Sort
        {
            get
            {
                return _sortType;
            }
            set
            {
                _sortType = value;
            }
        }

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
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            using (var db = new UserTasksDB())
                db.Insert(task);

            TasksDbUpdated(this, new EventArgs());
        }

        public void UpdateTask(UserTask task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            using (var db = new UserTasksDB())
                db.Update(task);

            TasksDbUpdated(this, new EventArgs());
        }

        public void DeleteTask(UserTask task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            if (task.Id <= 0) //С 1?
                throw new ArgumentOutOfRangeException($"Id of {task} should be positive");

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
            if (string.IsNullOrWhiteSpace(date))
                throw new ArgumentException($"{nameof(date)} should not to be null or empty.");

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
            if (string.IsNullOrWhiteSpace(beginDate) || string.IsNullOrWhiteSpace(endDate))
                throw new ArgumentException($"{nameof(beginDate)} or {nameof(endDate)} should not to be null or empty.");

            List<UserTask> tasks;
            Expression<Func<UserTask, bool>> compare;

            if (beginDate == endDate) //Вынести в поле класса?
                compare = t => t.TaskDate == beginDate;
            else
                compare = t => t.TaskDate.CompareTo(beginDate) >= 0 && t.TaskDate.CompareTo(endDate) <= 0;

            using (var db = new UserTasksDB())
            {
                var query = db.UserTasks.Where(compare);
                var filterResult = _taskFilter.Filter(query, _filterType);

                tasks = filterResult.ToList();
            }
            return tasks;
        }

        public List<string> GetAllTaskDates()
        {
            using (var db = new UserTasksDB())
            {
                return db.UserTasks.Select(t => t.TaskDate).ToList();
            }
        }
    }
}
