using System.Linq;
using TaskManagerModel.DataModels;
using TaskManagerCommon.Components;

namespace TaskManagerModel.DataModelComponents
{
    public interface ITaskFilter
    {
        IQueryable<UserTask> Filter(IQueryable<UserTask> query, FilterType filter);
    }
}
