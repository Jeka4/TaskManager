using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Components;

namespace TaskManager.Views
{
    public class UserTaskView
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime TaskDate { get; set; }
        public DateTime NotifyDate { get; set; }
        public bool isNotified { get; set; }
        public IEnumerable<string> PriorityTypes
        {
            get
            {
                return Enum.GetNames(typeof(TaskPriority)).AsEnumerable();
            }
        }
    }
}
