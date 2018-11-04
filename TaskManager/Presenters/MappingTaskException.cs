using System;

namespace TaskManager.Presenters
{
    public class MappingTaskException : Exception
    {
        public MappingTaskException() { }
        public MappingTaskException(string message, Exception ex) : base(message, ex) { }
    }
}
