using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BlueTofuEngine.Core
{
    public class ServiceProviderNotBuiltException : Exception
    {
        public ServiceProviderNotBuiltException()
        {
        }

        public ServiceProviderNotBuiltException(string message) : base(message)
        {
        }

        public ServiceProviderNotBuiltException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ServiceProviderNotBuiltException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
