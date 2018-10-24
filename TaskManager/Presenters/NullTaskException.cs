using System;

namespace TaskManager.Presenters
{
    public class NullTaskException : Exception
    {
        public NullTaskException() { }
        public NullTaskException(string message, Exception ex) : base(message, ex) { }
    }
}
