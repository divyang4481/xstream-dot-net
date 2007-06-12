using System;
using System.Runtime.Serialization;

namespace Xstream.Core
{
    /// <summary>
    /// Exception that occurs then (de)serialization of an object fails.
    /// </summary>
    [Serializable]
    internal class ConversionException : Exception
    {
        public ConversionException(SerializationInfo info, StreamingContext context) : base(info, context) {}
        public ConversionException(string message) : base(message) {}
        public ConversionException(string message, Exception innerException) : base(message, innerException) {}
    }
}