using System;
using System.Linq;

namespace TaskManagerModel.Components
{
    public interface IContext : IDisposable
    {
        int Insert(UserTask task);
        int Update(UserTask task);
        int Delete(UserTask task);
        IQueryable<UserTask> GetUserTasksTable();
    }
}
