using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
