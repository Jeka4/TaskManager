using DataModels;
using System.Linq;
using TaskManager.DataModels;

namespace TaskManager.DataModelComponents
{
    public interface ITaskFilter
    {
        void Filter(IQueryable<UserTask> query, FilterType filter);
    }
}
