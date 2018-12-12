using System.Linq;
using TaskManagerCommon.Components;
using TaskManagerModel;
using TaskManagerModel.Components;

namespace TaskManagerUnitTest.Fakes
{
    class TasksFilterFake : ITaskFilter
    {
        public IQueryable<UserTask> Filter(IQueryable<UserTask> query, FilterType filter)
        {
            return query;
        }
    }
}
