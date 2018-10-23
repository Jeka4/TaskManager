using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using view = TaskManager.Views;

namespace TaskManager.PresenterComponents
{
    public interface IPriorityConverter
    {
        string ConvertToModelPriority(view.TaskPriority priority);

        view.TaskPriority ConvertToViewPriority(string priority);
    }
}
