using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FluentValidation;
using TaskManagerCommon.Components;
using TaskManagerModel.Components;
using TaskManagerModel.Validators;

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

        private readonly IContextFactory _contextFactory;

        public DataModel(IContextFactory contextFactory, ITaskFilter taskFilter)
        {
            _contextFactory = contextFactory;

            _taskFilter = taskFilter;
            _filterType = FilterType.All;
            _sortType = SortType.AscendingPriority;
        }

        public void AddTask(UserTask task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            var validator = new UserTaskValidator();
            validator.ValidateAndThrow(task, ruleSet: "Body");

            using (var context = _contextFactory.BuildContex())
            {
                context.Insert(task);
            }

            TasksDbUpdated(this, new EventArgs());
        }

        public void UpdateTask(UserTask task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            var validator = new UserTaskValidator();
            validator.ValidateAndThrow(task, ruleSet: "*");

            using (var context = _contextFactory.BuildContex())
            {
                context.Update(task);
            }

            TasksDbUpdated(this, new EventArgs());
        }

        public void DeleteTask(UserTask task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            var validator = new UserTaskValidator();
            validator.ValidateAndThrow(task, ruleSet: "Id");

            using (var context = _contextFactory.BuildContex())
            {
                context.Delete(task);
            }

            TasksDbUpdated(this, new EventArgs());
        }

        public List<UserTask> GetAllTasks()
        {
            List<UserTask> tasks;
            using (var context = _contextFactory.BuildContex())
            {
                var query = context.GetUserTasksTable();

                tasks = query.ToList();
            }
            return tasks;
        }

        public List<UserTask> GetTasksOfDay(DateTime date)
        {
            using (var context = _contextFactory.BuildContex())
            {
                var query = context.GetUserTasksTable().Where(t => t.TaskDate == date);
                var selectionResult = _taskFilter.Filter(query, _filterType).Sort(_sortType);

                var tasks = selectionResult.ToList();
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

            using (var context = _contextFactory.BuildContex())
            {
                var query = context.GetUserTasksTable().Where(compare);
                var selectionResult = _taskFilter.Filter(query, _filterType).Sort(_sortType);

                tasks = selectionResult.ToList();
            }
            return tasks;
        }

        public List<DateTime> GetAllTaskDates()
        {
            using (var context = _contextFactory.BuildContex())
            {
                return context.GetUserTasksTable().Select(t => t.TaskDate).ToList();
            }
        }
    }
}
