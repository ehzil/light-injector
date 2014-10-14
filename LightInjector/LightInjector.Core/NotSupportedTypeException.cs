using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightInjector.Core
{
    [Serializable]
    internal class NotSupportedTypeException : Exception
    {
        public NotSupportedTypeException() { }
        public NotSupportedTypeException(string message) : base(message) { }
        public NotSupportedTypeException(string message, Exception inner) : base(message, inner) { }
        protected NotSupportedTypeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
