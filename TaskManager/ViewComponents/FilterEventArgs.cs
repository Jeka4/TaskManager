using System;
using TaskManager.Components;

namespace TaskManager.ViewComponents
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
