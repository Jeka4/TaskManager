using System.Linq;
using TaskManager.DataModels;

namespace TaskManager.DataModelComponents
{
    public interface ITaskFilter
    {
        IQueryable<UserTask> Filter(IQueryable<UserTask> query, FilterType filter);
    }
}
