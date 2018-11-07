using System.Linq;
using TaskManager.DataModels;
using TaskManager.Components;

namespace TaskManager.DataModelComponents
{
    public interface ITaskFilter
    {
        IQueryable<UserTask> Filter(IQueryable<UserTask> query, FilterType filter);
    }
}
