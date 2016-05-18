using System;

namespace SetNamespace
{
    /// <summary>
    /// the exception that is thrown when the program tries to perform actions with non-existent objects
    /// </summary>
    [Serializable]
    public class NonExistentItemException : ApplicationException
    {
        public NonExistentItemException() { }
        public NonExistentItemException(string message) : base(message) { }
        public NonExistentItemException(string message, Exception inner) : base(message, inner) { }
        protected NonExistentItemException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}