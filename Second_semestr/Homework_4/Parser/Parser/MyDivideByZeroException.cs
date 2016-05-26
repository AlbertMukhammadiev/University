using System;

namespace ParseTreeNamespace
{
    /// <summary>
    /// the exception that is thrown when right son of Division is zero
    /// </summary>
    [Serializable]
    public class MyDivideByZeroException : ApplicationException
    {
        public MyDivideByZeroException() { }
        public MyDivideByZeroException(string message) : base(message) { }
        public MyDivideByZeroException(string message, Exception inner) : base(message, inner) { }
        protected MyDivideByZeroException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
