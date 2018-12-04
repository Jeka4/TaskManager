using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
