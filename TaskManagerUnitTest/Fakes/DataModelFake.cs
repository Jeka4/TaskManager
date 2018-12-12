using System;
using System.Collections.Generic;
using TaskManagerCommon.Components;
using TaskManagerModel;

namespace TaskManagerUnitTest.Fakes
{
    class DataModelFake : IDataModel
    {
        public FilterType Filter { get; set; }

        public SortType Sort { get; set; }

        public event EventHandler TasksDbUpdated;

        public void AddTask(UserTask task)
        {

        }

        public void DeleteAllTasks()
        {

        }

        public void DeleteCompletedTasks(DateTime today)
        {

        }

        public void DeleteTask(long id)
        {

        }

        public void DeleteTasks(List<long> tasksIdList)
        {

        }

        public List<DateTime> GetAllTaskDates()
        {
            return new List<DateTime>();
        }

        public List<UserTask> GetAllTasks()
        {
            return new List<UserTask>();
        }

        public List<UserTask> GetTasksOfDay(DateTime date)
        {
            return new List<UserTask>();
        }

        public List<UserTask> GetTasksOfDays(DateTime beginDate, DateTime endDate)
        {
            return new List<UserTask>();
        }

        public void UpdateTask(UserTask task)
        {

        }
    }
}
