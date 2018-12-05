using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagerModel;
using TaskManagerPresenter.Components;
using TaskManagerView;
using TaskManagerView.Components;

namespace TaskManagerPresenter
{
    public class TasksControlPresenter : ITasksControlPresenter
    {
        private readonly ITaskManagerWindowFactory _tasksManagerWindowFactory;
        private readonly IDataModel _dataModel;
        private readonly IPriorityConverter _priorityConverter;
        private ITasksManagerWindow _tasksManagerWindow;

        public TasksControlPresenter(ITaskManagerWindowFactory tasksManagerWindowFactory, IDataModel dataModel, IPriorityConverter priorityConverter)
        {
            _tasksManagerWindowFactory = tasksManagerWindowFactory;
            _dataModel = dataModel;
            _priorityConverter = priorityConverter;
        }

        public void Initialize()
        {

        }

        public void ShowTasksControlWindow()
        {
            if (_tasksManagerWindow != null)
                return;

            _tasksManagerWindow = _tasksManagerWindowFactory.ShowTaskManagerWindow();
            _tasksManagerWindow.TasksListNeedUpdate += WindowOnTasksListNeedUpdate;
            _tasksManagerWindow.UserTasksDeleted += TasksManagerWindowOnUserTasksDeleted;
            _tasksManagerWindow.SelectionListChanged += TasksManagerWindowOnSelectionListChanged;
            _tasksManagerWindow.Closed += WindowOnClosed;

            _tasksManagerWindow.EnableDeleteButton(false);
            _tasksManagerWindow.Initialize();
        }

        public void RefreshTasksList()
        {
            _tasksManagerWindow?.SetUserTasksToTasksList(LoadAllTasks());
        }

        private void WindowOnClosed(object sender, EventArgs eventArgs)
        {
            _tasksManagerWindow = null;
        }

        private void WindowOnTasksListNeedUpdate(object sender, EventArgs eventArgs)
        {
            RefreshTasksList();
        }

        private void TasksManagerWindowOnUserTasksDeleted(object sender, UserTasksListEventArgs userTasksListEventArgs)
        {
            DeleteTasks(userTasksListEventArgs?.UserTasksList);
        }

        private void TasksManagerWindowOnSelectionListChanged(object sender, EventArgs eventArgs)
        {
            _tasksManagerWindow?.EnableDeleteButton(_tasksManagerWindow.IsTaskSelected);
        }

        private List<UserTaskView> LoadAllTasks()
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

        private void DeleteTasks(List<UserTaskView> tasksList)
        {
            if (tasksList == null)
                throw new ArgumentNullException(nameof(tasksList));

            try
            {
                var idsForDataModel = tasksList.Select(t => t.Id).ToList();

                _dataModel.DeleteTasks(idsForDataModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
