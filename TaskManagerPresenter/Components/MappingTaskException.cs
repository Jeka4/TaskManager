using System;

namespace TaskManagerPresenter.Components
{
    public class MappingTaskException : Exception
    {
        public MappingTaskException() { }
        public MappingTaskException(string message, Exception ex) : base(message, ex) { }
    }
}
