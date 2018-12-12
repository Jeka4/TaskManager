using System;
using System.Collections.Generic;
using TaskManagerCommon.Components;
using TaskManagerModel;

namespace TaskManagerUnitTest.Fakes
{
    class DataModelFake : IDataModel
    {
        public FilterType Filter
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public SortType Sort
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler TasksDbUpdated;

        public void AddTask(UserTask task)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllTasks()
        {
            throw new NotImplementedException();
        }

        public void DeleteCompletedTasks(DateTime today)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(long id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTasks(List<long> tasksIdList)
        {
            throw new NotImplementedException();
        }

        public List<DateTime> GetAllTaskDates()
        {
            throw new NotImplementedException();
        }

        public List<UserTask> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public List<UserTask> GetTasksOfDay(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<UserTask> GetTasksOfDays(DateTime beginDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(UserTask task)
        {
            throw new NotImplementedException();
        }
    }
}
