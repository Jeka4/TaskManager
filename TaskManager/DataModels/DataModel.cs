using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using DataModels;

namespace TaskManager.DataModels
{
    public enum SortType { AscendingPriority, DescendingPriority }

    public enum FilterType { All, LowPriority, MediumPriority, HighPriority }

    public class DataModel : IDataModel
    {
        public event EventHandler TasksDBUpdated;

        public List<UserTask> GetAllTasks()
        {
            List<UserTask> tasks = new List<UserTask>();
            using (var db = new UserTasksDB())
            {
                var query = from t in db.UserTasks
                            from d in db.TaskDates.Where(q => q.Id == t.TaskDateID).DefaultIfEmpty() //?????
                            from n in db.NotifyDates.Where(q => q.Id == t.NotifyDateID).DefaultIfEmpty()
                            select new UserTask //Можно расширить класс, добавив конструктор с TaskDate, NotifyDate
                            {
                                Name = t.Name,
                                Description = t.Description,
                                Priority = t.Priority,
                                TaskDateID = t.TaskDateID,
                                TaskDate = d,
                                NotifyDateID = t.NotifyDateID,
                                NotifyDate = n
                            };

                tasks = query.ToList();
            }
            return tasks;
        }

        public List<UserTask> GetTasksOfDay(string date) //Использовать DateTime? + дублирование кода
        {
            List<UserTask> tasks = new List<UserTask>();
            using (var db = new UserTasksDB())
            {
                var query = from t in db.UserTasks
                            from d in db.TaskDates.Where(q => q.Id == t.TaskDateID).DefaultIfEmpty() //?????
                            from n in db.NotifyDates.Where(q => q.Id == t.NotifyDateID).DefaultIfEmpty()
                            where d.Date == date
                            select new UserTask
                            {
                                Name = t.Name,
                                Description = t.Description,
                                Priority = t.Priority,
                                TaskDateID = t.TaskDateID,
                                TaskDate = d,
                                NotifyDateID = t.NotifyDateID,
                                NotifyDate = n
                            };

                tasks = query.ToList();
            }
            return tasks;
        }

        public void SortBy(SortType sort)
        {
            throw new NotImplementedException();
        }

        public void FilterBy(FilterType filter)
        {
            throw new NotImplementedException();
        }
    }
}
