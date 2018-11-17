using System;
using TaskManagerCommon.Components;

namespace TaskManagerView.Components
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
