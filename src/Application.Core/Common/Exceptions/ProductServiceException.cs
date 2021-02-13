namespace Application.Common.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ProductServiceException : Exception
    {
        public ProductServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ProductServiceException(string message) : base(message)
        {
        }
    }
}