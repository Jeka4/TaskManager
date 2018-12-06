using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCommon.Components;

namespace TaskManagerView.Components
{
    public class SortEventArgs : EventArgs
    {
        public SortType Sort { get; set; }

        public SortEventArgs(SortType sort)
        {
            Sort = sort;
        }
    }
}
