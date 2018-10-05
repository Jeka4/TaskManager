using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class BDUserTask
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string TaskDate { get; set; }
        public string NotifyDate { get; set; }
    }
}
