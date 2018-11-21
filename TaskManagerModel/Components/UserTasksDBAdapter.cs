using LinqToDB;

namespace TaskManagerModel.Components
{
    internal class UserTasksDbAdapter : IContext
    {
        private readonly UserTasksDB _contex;

        private bool _disposed;

        public UserTasksDbAdapter()
        {
            _contex = new UserTasksDB();
            _disposed = false;
        }

        public int Insert(UserTask task)
        {
            return _contex.Insert(task);
        }

        public int Update(UserTask task)
        {
            return _contex.Update(task);
        }

        public int Delete(UserTask task)
        {
            return _contex.Delete(task);
        }

        public ITable<UserTask> GetUserTasksTable()
        {
            return _contex.UserTasks;
        }

        public void Dispose()
        {
            _contex?.Dispose();
            _disposed = true;
        }

        ~UserTasksDbAdapter()
        {
            if (!_disposed)
                Dispose();
        }
    }
}
