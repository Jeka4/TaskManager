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

            _dataModel.TasksDbUpdated += DataModel_TasksDBUpdated;

            _mainWindow.EnableEditRemoveControls(false);
            _mainWindow.CurrentCalendarDateChanged += MainWindow_CurrentCalendarDateChanged;
            _mainWindow.SelectionListUpdated += MainWindow_SelectionListUpdated;
            _mainWindow.UserTaskAdded += MainWindow_UserTaskAdded;
            _mainWindow.UserTaskUpdated += MainWindow_UserTaskUpdated;
            _mainWindow.UserTaskDeleted += MainWindow_UserTaskDeleted;
            _mainWindow.FilterTypeChanged += MainWindow_FilterTypeChanged;


            RefreshViewTasksList(_mainWindow.DateIntervalSelected);
            _mainWindow.Show();
        }

        private void MainWindow_FilterTypeChanged(object sender, FilterEventArgs e)
        {
            var filter = e.Filter; //Исключение?

            _dataModel.Filter = filter;
            RefreshViewTasksList(_mainWindow.DateIntervalSelected);
        }

        private void MainWindow_UserTaskDeleted(object sender, UserTaskEventArgs e)
        {
            RemoveTask(e.UserTaskView);
        }

        private void MainWindow_UserTaskUpdated(object sender, UserTaskEventArgs e)
        {
            EditTask(e.UserTaskView);
        }

        private void MainWindow_UserTaskAdded(object sender, UserTaskEventArgs e)
        {
            AddTask(e.UserTaskView);
        }

        private void MainWindow_SelectionListUpdated(object sender, EventArgs e)
        {
            _mainWindow.EnableEditRemoveControls(_mainWindow.TaskSelected);
        }

        private void DataModel_TasksDBUpdated(object sender, EventArgs e)
        {
            RefreshViewTasksList(_mainWindow.DateIntervalSelected);
        }

        private void MainWindow_CurrentCalendarDateChanged(object sender, TaskDateIntervalEventArg e)
        {
            RefreshViewTasksList(_mainWindow.DateIntervalSelected);
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

            _dataModel.AddTask(userTask);
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
