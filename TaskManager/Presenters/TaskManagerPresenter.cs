using System;
using System.Collections.Generic;
using TaskManager.Views;
using TaskManager.DataModels;
using TaskManager.PresenterComponents;
using TaskManager.ViewComponents;
using System.Linq;

namespace TaskManager.Presenters
{
    public class TaskManagerPresenter : ITaskManagerPresenter
    {
        private IMainWindow _mainWindow;
        private IDataModel _dataModel;
        private readonly IDateConverter _dateConverter;
        private readonly IPriorityConverter _priorityConverter;

        public TaskManagerPresenter(IMainWindow mainWindow, IDataModel dataModel, IDateConverter dateConverter, IPriorityConverter priorityConverter)
        {
            _mainWindow = mainWindow;
            _dataModel = dataModel;
            _dateConverter = dateConverter;
            _priorityConverter = priorityConverter;

            _dataModel.TasksDbUpdated += DataModel_TasksDBUpdated;

            _mainWindow.EnableEditRemoveControls(false);
            _mainWindow.SetUserTasksToTasksList(LoadTasksOfDay(_mainWindow.DateSelected));
            _mainWindow.CurrentCalendarDateChanged += MainWindow_CurrentCalendarDateChanged;
            _mainWindow.SelectionListUpdated += MainWindow_SelectionListUpdated;
            _mainWindow.UserTaskAdded += MainWindow_UserTaskAdded;
            _mainWindow.UserTaskUpdated += MainWindow_UserTaskUpdated;
            _mainWindow.UserTaskDeleted += MainWindow_UserTaskDeleted;
            _mainWindow.FilterTypeChanged += MainWindow_FilterTypeChanged;
            _mainWindow.Show();
        }

        private void MainWindow_FilterTypeChanged(object sender, EventArgs e)
        {
            var filter = _mainWindow.ComboFilter;

            _dataModel.FilterBy(filter);
            RefreshViewTasksList(_mainWindow.DateSelected);
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
            RefreshViewTasksList(_mainWindow.DateSelected);
        }

        private void MainWindow_CurrentCalendarDateChanged(object sender, TaskDateEventArg e)
        {
            RefreshViewTasksList(e.Date);
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

        public void RefreshViewTasksList(DateTime day)
        {
            _mainWindow.SetUserTasksToTasksList(LoadTasksOfDay(day));
        }

        public List<UserTaskView> LoadAllTasks()
        {
            List<UserTask> tasks = _dataModel.GetAllTasks();

            List<UserTaskView> tasksForView = new List<UserTaskView>();
            try
            {
                tasksForView.AddRange(tasks.Select(task => new UserTaskView
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    Priority = _priorityConverter.ConvertToViewPriority(task.Priority),
                    TaskDate = _dateConverter.ParseStringToDate(task.TaskDate),
                    NotifyDate = _dateConverter.ParseStringToDate(task.NotifyDate),
                    IsNotified = Convert.ToBoolean(task.IsNotified)
                }));

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

            List<UserTaskView> tasksForView = new List<UserTaskView>();

            try
            {
                tasksForView.AddRange(tasks.Select(task => new UserTaskView
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    Priority = _priorityConverter.ConvertToViewPriority(task.Priority),
                    TaskDate = _dateConverter.ParseStringToDate(task.TaskDate),
                    NotifyDate = _dateConverter.ParseStringToDate(task.NotifyDate),
                    IsNotified = Convert.ToBoolean(task.IsNotified)
                }));

                return tasksForView;
            }
            catch (Exception ex)
            {
                throw new MappingTaskException(ex.Message, ex);
            }
        }
    }
}
