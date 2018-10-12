using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Views
{
    public class UserTaskEventArgs : EventArgs
    {
        public UserTaskView UserTaskView { get; set; }

        public UserTaskEventArgs(UserTaskView userTask)
        {
            UserTaskView = userTask;
        }
    }
}
