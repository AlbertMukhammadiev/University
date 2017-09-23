using System;

namespace SetNamespace
{
    /// <summary>
    /// the exception that is thrown when some functions are called from an empty Set
    /// </summary>
    [Serializable]
    public class EmptySetException : ApplicationException
    {
        public EmptySetException() { }
        public EmptySetException(string message) : base(message) { }
        public EmptySetException(string message, Exception inner) : base(message, inner) { }
        protected EmptySetException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
