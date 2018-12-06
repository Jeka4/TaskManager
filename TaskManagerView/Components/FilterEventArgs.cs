using System;
using TaskManagerCommon.Components;

namespace TaskManagerView.Components
{
    public class FilterEventArgs : EventArgs
    {
        public FilterType Filter { get; set; }

        public FilterEventArgs(FilterType filter)
        {
            Filter = filter;
        }
    }
}
