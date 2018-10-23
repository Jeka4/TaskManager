using DataModels;
using System.Linq;
using TaskManager.DataModels;

namespace TaskManager.DataModelComponents
{
    class TasksFilter : ITaskFilter
    {
        public IQueryable<UserTask> Filter(IQueryable<UserTask> query, FilterType filter)
        {
            return null;
        }
    }
}
