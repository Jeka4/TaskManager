using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using TaskManager.Views;
using TaskManager.DataModels;

namespace TaskManager.Presenters
{
    public class TaskManagerPresenter : ITaskManagerPresenter
    {
        private IMainWindow _mainWindow;
        private IDataModel _dataModel;

        public TaskManagerPresenter(IMainWindow mainWindow, IDataModel dataModel)
        {
            _mainWindow = mainWindow;
            _dataModel = dataModel;

            _dataModel.TasksDBUpdated += dataModel_TasksDBUpdated;

            _mainWindow.EnableEditRemoveControls(false);
            _mainWindow.SetUserTasksToTasksList(LoadTasksOfDay(_mainWindow.DateSelected));
            _mainWindow.CurrentCalendarDateChanged += mainWindow_CurrentCalendarDateChanged;
            _mainWindow.SelectionListUpdated += mainWindow_SelectionListUpdated;
            _mainWindow.UserTaskAdded += mainWindow_UserTaskAdded;
            _mainWindow.UserTaskUpdated += mainWindow_UserTaskUpdated;
            _mainWindow.UserTaskDeleted += mainWindow_UserTaskDeleted;
            _mainWindow.Show();

            //Test
            //LoadAllTasks();
        }

        private void mainWindow_UserTaskDeleted(object sender, UserTaskEventArgs e)
        {
            RemoveTask(e.UserTaskView);
        }

        private void mainWindow_UserTaskUpdated(object sender, UserTaskEventArgs e)
        {
            EditTask(e.UserTaskView);
        }

        private void mainWindow_UserTaskAdded(object sender, UserTaskEventArgs e)
        {
            AddTask(e.UserTaskView);
        }

        private void mainWindow_SelectionListUpdated(object sender, EventArgs e)
        {
            _mainWindow.EnableEditRemoveControls(_mainWindow.TaskSelected);
        }

        private void dataModel_TasksDBUpdated(object sender, EventArgs e)
        {
            _mainWindow.SetUserTasksToTasksList(LoadTasksOfDay(_mainWindow.DateSelected));
        }

        private void mainWindow_CurrentCalendarDateChanged(object sender, TaskDateEventArg e)
        {
            _mainWindow.SetUserTasksToTasksList(LoadTasksOfDay(e.Date));
        }

        public void AddTask(UserTaskView task)
        {
            if (task == null)
                return;

            UserTask userTask = new UserTask
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Priority = task.Priority.ToString(),
                Notifed = 0
            };

            userTask.TaskDate = new TaskDate { Date = task.TaskDate.ToShortDateString() };
            userTask.NotifyDate = new NotifyDate { Date = task.NotifyDate.ToShortDateString() };

            _dataModel.AddTask(userTask);
        }

        public void EditTask(UserTaskView task)
        {
            if (task == null)
                return;

            UserTask userTask = new UserTask
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Priority = task.Priority.ToString(),
                Notifed = 0
            };

            userTask.TaskDate = new TaskDate { Date = task.TaskDate.ToShortDateString() };
            userTask.NotifyDate = new NotifyDate { Date = task.NotifyDate.ToShortDateString() };

            _dataModel.UpdateTask(userTask);
        }

        public void RemoveTask(UserTaskView task)
        {
            if (task == null)
                return;

            UserTask userTask = new UserTask
            {
                Id = task.Id
            };

            _dataModel.DeleteTask(userTask);
        }

        public List<UserTaskView> LoadAllTasks()
        {
            List<UserTask> tasks = _dataModel.GetAllTasks();

            List<UserTaskView> tasksForView = new List<UserTaskView>();

            foreach (var task in tasks)
            {
                tasksForView.Add(
                    new UserTaskView {
                        Id = task.Id,
                        Name = task.Name,
                        Description = task.Description,
                        Priority = TaskPriority.High, //
                        TaskDate = DateTime.Parse(task.TaskDate.Date),
                        NotifyDate = DateTime.Parse(task.NotifyDate.Date)
                    });
            }

            return tasksForView;
        }

        public List<UserTaskView> LoadTasksOfDay(DateTime day)
        {
            List<UserTask> tasks = _dataModel.GetTasksOfDay(day.ToShortDateString());

            List<UserTaskView> tasksForView = new List<UserTaskView>();

            foreach (var task in tasks)
            {
                tasksForView.Add(
                    new UserTaskView
                    {
                        Id = task.Id,
                        Name = task.Name,
                        Description = task.Description,
                        Priority = TaskPriority.High, //
                        TaskDate = DateTime.Parse(task.TaskDate.Date),
                        NotifyDate = DateTime.Parse(task.NotifyDate.Date)
                    });
            }

            return tasksForView;
        }
    }
}
