using DataModels;
using System.Linq;
using TaskManager.DataModels;

namespace TaskManager.DataModelComponents
{
    interface ITaskFilter
    {
        IQueryable<UserTask> Filter(IQueryable<UserTask> query, FilterType filter);
    }
}
