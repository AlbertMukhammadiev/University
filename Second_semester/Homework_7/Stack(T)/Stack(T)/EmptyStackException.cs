using System;

namespace StackNamespace
{
    /// <summary>
    /// the exception that is thrown when some functions are called from an empty Stack
    /// </summary>
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
