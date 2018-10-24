using System;

namespace TaskManager.Views
{
    public class TaskDateEventArg : EventArgs
    {
        public DateTime Date { get; set; }
        public TaskDateEventArg(DateTime date)
        {
            Date = date;
        }
    }
}
