using System.Linq;
using TaskManagerModel;
using TaskManagerCommon.Components;

namespace TaskManagerModel.Components
{
    public interface ITaskFilter
    {
        IQueryable<UserTask> Filter(IQueryable<UserTask> query, FilterType filter);
    }
}
