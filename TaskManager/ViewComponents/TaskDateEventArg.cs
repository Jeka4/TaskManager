using System;

namespace TaskManager.ViewComponents
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
