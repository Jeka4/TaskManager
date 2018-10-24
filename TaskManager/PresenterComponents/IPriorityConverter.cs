using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Components;

namespace TaskManager.PresenterComponents
{
    public interface IPriorityConverter
    {
        string ConvertToModelPriority(TaskPriority priority);

        TaskPriority ConvertToViewPriority(string priority);
    }
}
