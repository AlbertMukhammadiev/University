using System;

namespace BinaryTreeNamespace
{
    /// <summary>
    /// the exception that is thrown when elements with dublicate keys are added to the Unique List
    /// </summary>
    [Serializable]
    public class DuplicateKeysException : ApplicationException
    {
        public DuplicateKeysException() { }
        public DuplicateKeysException(string message) : base(message) { }
        public DuplicateKeysException(string message, Exception inner) : base(message, inner) { }
        protected DuplicateKeysException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}