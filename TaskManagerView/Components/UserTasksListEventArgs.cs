using System;
using System.Collections.Generic;

namespace TaskManagerView.Components
{
    public class UserTasksListEventArgs : EventArgs
    {
        public List<UserTaskView> UserTasksList { get; set; }

        public UserTasksListEventArgs(List<UserTaskView> tasks)
        {
            UserTasksList = tasks;
        }
    }
}
