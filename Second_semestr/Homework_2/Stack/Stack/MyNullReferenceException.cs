using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyException
{

    [Serializable]
    public class MyNullReferenceException : ApplicationException
    {
        public MyNullReferenceException() { }
        public MyNullReferenceException(string message) : base(message) { }
        public MyNullReferenceException(string message, Exception inner) : base(message, inner) { }
        protected MyNullReferenceException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
