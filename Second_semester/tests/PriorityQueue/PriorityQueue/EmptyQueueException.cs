using System;

namespace MyException
{
    [Serializable]
    public class EmptyQueueException : ApplicationException
    {
        public EmptyQueueException() { }
        public EmptyQueueException(string message) : base(message) { }
        public EmptyQueueException(string message, Exception inner) : base(message, inner) { }
        protected EmptyQueueException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
