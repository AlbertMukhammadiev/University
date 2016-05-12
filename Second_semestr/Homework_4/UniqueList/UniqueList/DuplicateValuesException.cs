using System;

namespace UniqueListNamespace
{
    /// <summary>
    /// the exception that is thrown when duplicate elements are added to the Unique List
    /// </summary>
    [Serializable]
    public class DuplicateValuesException : ApplicationException
    {
        public DuplicateValuesException() { }
        public DuplicateValuesException(string message) : base(message) { }
        public DuplicateValuesException(string message, Exception inner) : base(message, inner) { }
        protected DuplicateValuesException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}