using System;
using System.Collections.Generic;
using TaskManagerModel;
using System.Linq;
using TaskManagerCommon.Components;
using TaskManagerPresenter.Components;
using TaskManagerView;
using TaskManagerView.Components;

namespace TaskManagerPresenter
{
    public class Presenter : IPresenter
    {
        private IMainWindow _mainWindow;
        private IDataModel _dataModel;
        private readonly IPriorityConverter _priorityConverter;

        public Presenter(IMainWindow mainWindow, IDataModel dataModel, IPriorityConverter priorityConverter)
        {
            _mainWindow = mainWindow;
            _dataModel = dataModel;
            _priorityConverter = priorityConverter;
        }

        public void Initialize()
        {
            _mainWindow.Initialize();
            _mainWindow.EnableEditRemoveControls(false);
        }

        public void SortTypeChange(SortType sort)
        {
            if(sort == SortType.Undefined)
                throw new ArgumentException($"{nameof(sort)} is Undefined");

            _dataModel.Sort = sort;
        }

        public void FilterTypeChange(FilterType filter)
        {
            if (filter == FilterType.Undefined)
                throw new ArgumentException($"{nameof(filter)} is Undefined");

            _dataModel.Filter = filter;
        }

        public void SelectionListUpdated()
        {
            _mainWindow.EnableEditRemoveControls(_mainWindow.TaskSelected);
        }

        public void AddTask(UserTaskView task)
        {
            if (task == null)
                throw new NullTaskException();

            UserTask userTask = new UserTask
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Priority = _priorityConverter.ConvertToModelPriority(task.Priority),
                IsNotified = false,
                TaskDate = task.TaskDate,
                NotifyDate = task.NotifyDate
            };

            try
            {
                _dataModel.AddTask(userTask);
            }
            catch (Exception ex)
            {
                _mainWindow.ShowMessageBox("Возникла ошибка при добавлении задачи");
            }
        }

        public void EditTask(UserTaskView task)
        {
            if (task == null)
                throw new NullTaskException();

            UserTask userTask = new UserTask
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Priority = _priorityConverter.ConvertToModelPriority(task.Priority),
                IsNotified = false,
                TaskDate = task.TaskDate,
                NotifyDate = task.NotifyDate
            };

            _dataModel.UpdateTask(userTask);
        }

        public void RemoveTask(UserTaskView task)
        {
            if (task == null)
                throw new NullTaskException();

            UserTask userTask = new UserTask
            {
                Id = task.Id
            };

            _dataModel.DeleteTask(userTask);
        }

        public void RefreshViewTasksList(DateInterval dateInterval)
        {
            _mainWindow.SetUserTasksToTasksList(LoadTasksOfDays(dateInterval));
        }

        public void RefreshViewHighlightList()
        {
            var tasksDates = _dataModel.GetAllTaskDates().ToList();
            _mainWindow.SetHighlightDates(tasksDates);
        }

        public List<UserTaskView> LoadAllTasks()
        {
            List<UserTask> tasks = _dataModel.GetAllTasks();

            try
            {
                var tasksForView = tasks.Select(task => new UserTaskView
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    Priority = _priorityConverter.ConvertToViewPriority(task.Priority),
                    TaskDate = task.TaskDate,
                    NotifyDate = task.NotifyDate,
                    IsNotified = task.IsNotified
                }).ToList();

                return tasksForView;
            }
            catch (Exception ex)
            {
                throw new MappingTaskException(ex.Message, ex);
            }
        }

        public List<UserTaskView> LoadTasksOfDay(DateTime day)
        {
            List<UserTask> tasks = _dataModel.GetTasksOfDay(day);

            try
            {
                var tasksForView = tasks.Select(task => new UserTaskView
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    Priority = _priorityConverter.ConvertToViewPriority(task.Priority),
                    TaskDate = task.TaskDate,
                    NotifyDate = task.NotifyDate,
                    IsNotified = task.IsNotified
                }).ToList();

                return tasksForView;
            }
            catch (Exception ex)
            {
                throw new MappingTaskException(ex.Message, ex);
            }
        }

        public List<UserTaskView> LoadTasksOfDays(DateInterval dateInterval)
        {
            List<UserTask> tasks = _dataModel.GetTasksOfDays(
                dateInterval.BeginDate,
                dateInterval.EndDate
                );

            List<UserTaskView> tasksForView;

            try
            {
                tasksForView = tasks.Select(task => new UserTaskView
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    Priority = _priorityConverter.ConvertToViewPriority(task.Priority),
                    TaskDate = task.TaskDate,
                    NotifyDate = task.NotifyDate,
                    IsNotified = task.IsNotified
                }).ToList();

                return tasksForView;
            }
            catch (Exception ex)
            {
                throw new MappingTaskException(ex.Message, ex);
            }
        }
    }
}
