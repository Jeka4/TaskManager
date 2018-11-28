using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerView.Components
{
    public interface ITaskManagerWindowFactory
    {
        ITasksManagerWindow ShowTaskManagerWindow();
    }
}
