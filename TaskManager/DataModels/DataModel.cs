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
        public event EventHandler TasksDBUpdated = delegate { };

        public void AddTask(UserTask task)
        {
            using (var db = new UserTasksDB())
            {
                db.BeginTransaction(System.Data.IsolationLevel.Serializable);

                task.TaskDateID = (from d in db.TaskDates
                                    where d.Date == task.TaskDate.Date
                                    select d.Id).FirstOrDefault();

                task.NotifyDateID = (from d in db.NotifyDates
                                   where d.Date == task.NotifyDate.Date
                                   select d.Id).FirstOrDefault();

                if (task.TaskDateID == 0)
                    task.TaskDateID = db.InsertWithInt64Identity(task.TaskDate);

                if (task.NotifyDateID == 0)
                    task.NotifyDateID = db.InsertWithInt64Identity(task.NotifyDate);

                db.Insert(task);

                db.CommitTransaction();
            }

            TasksDBUpdated(this, new EventArgs());
        }

        public void UpdateTask(UserTask task)
        {
            using (var db = new UserTasksDB())
            {
                db.BeginTransaction(System.Data.IsolationLevel.Serializable);

                task.TaskDateID = (from d in db.TaskDates
                                   where d.Date == task.TaskDate.Date
                                   select d.Id).FirstOrDefault();

                task.NotifyDateID = (from d in db.NotifyDates
                                     where d.Date == task.NotifyDate.Date
                                     select d.Id).FirstOrDefault();

                if (task.TaskDateID == 0)
                    task.TaskDateID = db.InsertWithInt64Identity(task.TaskDate);

                if (task.NotifyDateID == 0)
                    task.NotifyDateID = db.InsertWithInt64Identity(task.NotifyDate);

                db.Update(task);

                db.CommitTransaction();
            }

            TasksDBUpdated(this, new EventArgs());
        }

        public void DeleteTask(UserTask task)
        {
            using (var db = new UserTasksDB())
            {
                db.BeginTransaction(System.Data.IsolationLevel.Serializable);

                db.Delete(task);

                //Необходима очистка других таблиц

                db.CommitTransaction();
            }

            TasksDBUpdated(this, new EventArgs());
        }

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
                                Id = t.Id,
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
                                Id = t.Id,
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
