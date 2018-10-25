using System;

namespace TaskManager.ViewComponents
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
