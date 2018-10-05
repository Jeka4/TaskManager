using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public enum SortType { AscendingPriority, DescendingPriority }

    public enum FilterType { All, LowPriority, MediumPriority, HighPriority }

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
        }

        public void AddTask(UserTask task)
        {
            throw new NotImplementedException();
        }

        public void EditTask(UserTask task)
        {
            throw new NotImplementedException();
        }

        public void FilterBy(FilterType filter)
        {
            throw new NotImplementedException();
        }

        public List<UserTask> LoadAllTasks()
        {
            throw new NotImplementedException();
        }

        public List<UserTask> LoadTasksOfDay(DateTime day)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(int id)
        {
            throw new NotImplementedException();
        }

        public void SortBy(SortType sort)
        {
            throw new NotImplementedException();
        }
    }
}
