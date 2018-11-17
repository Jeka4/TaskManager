using System;

namespace TaskManagerView.ViewComponents
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
