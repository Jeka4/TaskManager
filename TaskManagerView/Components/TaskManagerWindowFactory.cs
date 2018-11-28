using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerView.Components
{
    public class TaskManagerWindowFactory : ITaskManagerWindowFactory
    {
        public ITasksManagerWindow ShowTaskManagerWindow()
        {
            return new TasksManagerWindow();
        }
    }
}
