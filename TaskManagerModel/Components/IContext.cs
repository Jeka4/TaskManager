using System;
using System.Data;
using LinqToDB;

namespace TaskManagerModel.Components
{
    public interface IContext : IDisposable
    {
        int Insert(UserTask task);
        int Update(UserTask task);
        int Delete(UserTask task);
        ITable<UserTask> GetUserTasksTable();
    }
}
