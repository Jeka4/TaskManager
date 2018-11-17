using System;

namespace TaskManagerPresenter.Presenters
{
    public class MappingTaskException : Exception
    {
        public MappingTaskException() { }
        public MappingTaskException(string message, Exception ex) : base(message, ex) { }
    }
}
