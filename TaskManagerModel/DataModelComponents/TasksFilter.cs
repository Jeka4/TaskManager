using System;
using System.Linq;
using TaskManagerModel.DataModels;
using TaskManagerCommon.Components;

namespace TaskManagerModel.DataModelComponents
{
    public class TasksFilter : ITaskFilter
    {
        public IQueryable<UserTask> Filter(IQueryable<UserTask> query, FilterType filter)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            IQueryable<UserTask> filterResult;

            switch (filter)
            {
                case FilterType.All:
                    filterResult = query;
                    break;
                case FilterType.HighPriority:
                    filterResult = query.Where(t => t.Priority == TaskPriority.High.ToString());
                    break;
                case FilterType.MediumPriority:
                    filterResult = query.Where(t => t.Priority == TaskPriority.Medium.ToString());
                    break;
                case FilterType.LowPriority:
                    filterResult = query.Where(t => t.Priority == TaskPriority.Low.ToString());
                    break;
                default:
                    throw new ArgumentException(nameof(filter));
            }

            return filterResult;
        }
    }
}
