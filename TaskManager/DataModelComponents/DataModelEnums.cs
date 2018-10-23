using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataModelComponents
{
    public enum SortType { AscendingPriority, DescendingPriority }

    public enum FilterType { All, LowPriority, MediumPriority, HighPriority }

    public enum TaskPriority { Low, Medium, High }
}
