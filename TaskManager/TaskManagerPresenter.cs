using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace TaskManager
{
    public class TaskManagerPresenter : ITaskManagerPresenter
    {
        private IMainWindow _mainWindow;
        private IDataModel _dataModel;

        public TaskManagerPresenter(IMainWindow mainWindow, IDataModel dataModel)
        {
            _mainWindow = mainWindow;
            _dataModel = dataModel;

            _mainWindow.BindPresenter(this);
            _mainWindow.Show();

            //Test
            LoadAllTasks();
        }

        public void AddTask(UserTaskView task)
        {
            throw new NotImplementedException();
        }

        public void EditTask(UserTaskView task)
        {
            throw new NotImplementedException();
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
            List<UserTask> tasks = _dataModel.GetTasksOfDay(new DateTime(2018, 10, 6));

            return null;
        }

        public void RemoveTask(int id)
        {
            throw new NotImplementedException();
        }
    }
}
