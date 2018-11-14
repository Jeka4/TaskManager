using System;

namespace TaskManager.Presenters
{
    public class NullTaskException : ArgumentNullException
    {
        public NullTaskException() { }
        public NullTaskException(string message, Exception ex) : base(message, ex) { }
    }
}
