using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Components;

namespace TaskManager.ViewComponents
{
    public class UserTaskView
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime TaskDate { get; set; }
        public DateTime NotifyDate { get; set; }
        public bool IsNotified { get; set; }
    }
}
