using System.Collections.Generic;
using System.Linq;
using TaskManagerModel;
using TaskManagerModel.Components;

namespace TaskManagerUnitTest.Fakes
{
    class DataModelContexFake : IContext
    {
        private readonly List<UserTask> _data;

        public DataModelContexFake(List<UserTask> data)
        {
            _data = data;
        }

        public int Delete(UserTask task)
        {
            return 1;
        }

        public void Dispose()
        {

        }

        public IQueryable<UserTask> GetUserTasksTable()
        {
            return _data.AsQueryable();
        }

        public int Insert(UserTask task)
        {
            return 1;
        }

        public int Update(UserTask task)
        {
            return 1;
        }
    }
}
