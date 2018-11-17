using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqToDB;
using TaskManagerCommon.Components;
using TaskManagerModel.Components;

namespace TaskManagerModel
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

        public List<UserTask> GetTasksOfDay(DateTime date)
        {
            using (var db = new UserTasksDB())
            {
                var query = db.UserTasks.Where(t => t.TaskDate == date);
                var filterResult = _taskFilter.Filter(query, _filterType);

                var tasks = filterResult.ToList();
                return tasks;
            }
        }

        public List<UserTask> GetTasksOfDays(DateTime beginDate, DateTime endDate)
        {
            List<UserTask> tasks;
            Expression<Func<UserTask, bool>> compare;

            if (beginDate == endDate) //Вынести в поле класса?
                compare = t => t.TaskDate == beginDate;
            else
                compare = t => t.TaskDate >= beginDate && t.TaskDate <= endDate;

            using (var db = new UserTasksDB())
            {
                var query = db.UserTasks.Where(compare);
                var filterResult = _taskFilter.Filter(query, _filterType);

                tasks = filterResult.ToList();
            }
            return tasks;
        }

        public List<DateTime> GetAllTaskDates()
        {
            using (var db = new UserTasksDB())
            {
                return db.UserTasks.Select(t => t.TaskDate).ToList();
            }
        }
    }
}
