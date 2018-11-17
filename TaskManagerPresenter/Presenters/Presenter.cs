using System;
using System.Collections.Generic;
using TaskManagerView.Views;
using TaskManagerModel.DataModels;
using TaskManagerPresenter.PresenterComponents;
using TaskManagerView.ViewComponents;
using System.Linq;
using TaskManagerCommon.Components;

namespace TaskManagerPresenter.Presenters
{
    public class Presenter : ITaskManagerPresenter
    {
        private IMainWindow _mainWindow;
        private IDataModel _dataModel;
        private readonly IDateConverter _dateConverter;
        private readonly IPriorityConverter _priorityConverter;

        public Presenter(IMainWindow mainWindow, IDataModel dataModel, IDateConverter dateConverter, IPriorityConverter priorityConverter)
        {
            _mainWindow = mainWindow;
            _dataModel = dataModel;
            _dateConverter = dateConverter;
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
                IsNotified = 0
            };

            userTask.TaskDate = _dateConverter.ConvertDateToString(task.TaskDate);
            userTask.NotifyDate = _dateConverter.ConvertDateToString(task.NotifyDate);

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
                IsNotified = 0
            };

            userTask.TaskDate = _dateConverter.ConvertDateToString(task.TaskDate);
            userTask.NotifyDate = _dateConverter.ConvertDateToString(task.NotifyDate);

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

            List<DateTime> tasksDates = _dataModel.GetAllTaskDates()
                                                  .Select(d => _dateConverter.ParseStringToDate(d))
                                                  .ToList();
            _mainWindow.SetHighlightDates(tasksDates);
        }

        public List<UserTaskView> LoadAllTasks()
        {
            List<UserTask> tasks = _dataModel.GetAllTasks();
            List<UserTaskView> tasksForView;

            try
            {
                tasksForView = tasks.Select(task => new UserTaskView
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    Priority = _priorityConverter.ConvertToViewPriority(task.Priority),
                    TaskDate = _dateConverter.ParseStringToDate(task.TaskDate),
                    NotifyDate = _dateConverter.ParseStringToDate(task.NotifyDate),
                    IsNotified = Convert.ToBoolean(task.IsNotified)
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
            List<UserTask> tasks = _dataModel.GetTasksOfDay(_dateConverter.ConvertDateToString(day));
            List<UserTaskView> tasksForView;

            try
            {
                tasksForView = tasks.Select(task => new UserTaskView
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    Priority = _priorityConverter.ConvertToViewPriority(task.Priority),
                    TaskDate = _dateConverter.ParseStringToDate(task.TaskDate),
                    NotifyDate = _dateConverter.ParseStringToDate(task.NotifyDate),
                    IsNotified = Convert.ToBoolean(task.IsNotified)
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
                _dateConverter.ConvertDateToString(dateInterval.BeginDate),
                _dateConverter.ConvertDateToString(dateInterval.EndDate)
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
                    TaskDate = _dateConverter.ParseStringToDate(task.TaskDate),
                    NotifyDate = _dateConverter.ParseStringToDate(task.NotifyDate),
                    IsNotified = Convert.ToBoolean(task.IsNotified)
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
