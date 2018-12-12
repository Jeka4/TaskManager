using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagerModel.Components
{
    public interface IContext : IDisposable
    {
        int Insert(UserTask task);
        int Update(UserTask task);
        int Delete(UserTask task);
        int DeleteByIds(List<long> tasksIdList);
        int DeleteById(long id);
        int DeleteAll();
        int DeleteCompleted(DateTime today);
        IQueryable<UserTask> GetUserTasksTable();
    }
}
