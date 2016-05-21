using System;

namespace StackNamespace
{
    /// <summary>
    /// the exception that is thrown when object is tried to put into crowded Stack
    /// </summary>
    [Serializable]
    public class StackOverflowException : ApplicationException
    {
        public StackOverflowException() { }
        public StackOverflowException(string message) : base(message) { }
        public StackOverflowException(string message, Exception inner) : base(message, inner) { }
        protected StackOverflowException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}