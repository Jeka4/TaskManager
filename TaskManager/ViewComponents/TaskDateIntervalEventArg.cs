using System;
using TaskManager.Components;

namespace TaskManager.ViewComponents
{
    public class TaskDateIntervalEventArg : EventArgs
    {
        public DateInterval DateInterval { get; set; }
        public TaskDateIntervalEventArg(DateInterval dateInterval)
        {
            DateInterval = dateInterval;
        }
    }
}
