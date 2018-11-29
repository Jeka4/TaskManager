using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagerModel;
using TaskManagerModel.Components;

namespace TaskManagerUnitTest
{
    class DataModelTestContex : IContext
    {
        private List<UserTask> _data;

        public DataModelTestContex()
        {
            _data = new List<UserTask>();
        }

        public int Delete(UserTask task)
        {
            _data = _data.Where(x => x.Id != task.Id).ToList();
            
            return 1;
        }

        public void Dispose()
        {
            _data = null;
        }

        public IQueryable<UserTask> GetUserTasksTable()
        {
            return _data.AsQueryable();
        }

        public int Insert(UserTask task)
        {
            //
            _data.Add(task);

            return 1;
        }

        public int Update(UserTask task)
        {
            var taskFromData = _data.Single(t => t.Id == task.Id);

            taskFromData.Name = task.Name;
            taskFromData.Description = task.Description;
            taskFromData.IsNotified = task.IsNotified;
            taskFromData.Priority = task.Priority;
            taskFromData.TaskDate = task.TaskDate;
            taskFromData.NotifyDate = task.NotifyDate;

            return 1;
        }
    }
}
