using System;

namespace ParseTreeNamespace
{
    /// <summary>
    /// the exception that is thrown when right son of Division is zero
    /// </summary>
    [Serializable]
    public class MyDividedByZeroException : ApplicationException
    {
        public MyDividedByZeroException() { }
        public MyDividedByZeroException(string message) : base(message) { }
        public MyDividedByZeroException(string message, Exception inner) : base(message, inner) { }
        protected MyDividedByZeroException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
