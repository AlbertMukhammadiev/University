using System;

namespace CalculatorNamespace
{
    /// <summary>
    /// the exception that is thrown when incorrect arithmetic expression is entered
    /// </summary>
    [Serializable]
    public class InvalidExpressionException : ApplicationException
    {
        public InvalidExpressionException() { }
        public InvalidExpressionException(string message) : base(message) { }
        public InvalidExpressionException(string message, Exception inner) : base(message, inner) { }
        protected InvalidExpressionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}