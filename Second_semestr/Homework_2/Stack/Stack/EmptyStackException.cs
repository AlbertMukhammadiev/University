using System;

namespace MyException
{
    [Serializable]
    public class EmptyStackException : ApplicationException
    {
        public EmptyStackException() { }
        public EmptyStackException(string message) : base(message) { }
        public EmptyStackException(string message, Exception inner) : base(message, inner) { }
        protected EmptyStackException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
