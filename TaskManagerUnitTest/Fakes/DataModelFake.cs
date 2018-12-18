using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagerCommon.Components;
using TaskManagerModel;

namespace TaskManagerUnitTest.Fakes
{
    class DataModelFake : IDataModel
    {
        public FilterType Filter { get; set; }

        public SortType Sort { get; set; }

        public event EventHandler TasksDbUpdated;

        private readonly List<UserTask> _data;

        public DataModelFake() : this(new List<UserTask>()) { }

        public DataModelFake(List<UserTask> data)
        {
            _data = data;
        }

        public void AddTask(UserTask task)
        {

        }

        public void UpdateTask(UserTask task)
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
            return _data;
        }

        public List<UserTask> GetTasksOfDay(DateTime date)
        {
            return _data.Where(t => t.TaskDate == date).ToList();
        }

        public List<UserTask> GetTasksOfDays(DateTime beginDate, DateTime endDate)
        {
            return _data.Where(t => t.TaskDate >= beginDate && t.TaskDate <= endDate).ToList();
        }

        public List<DateTime> GetTaskNotifyDates(DateTime day)
        {
            return new List<DateTime>();
        }
    }
}
