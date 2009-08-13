using System;
using System.Collections;

namespace Xstream.Core
{
    /// <summary>
    /// Easy facade class used to (de)serialize objects to and from XML.
    /// This class uses a default MarshalContext that is capable of (de)
    /// serializing almost all objects.
    /// </summary>
    public partial class XStream
    {
        public virtual T FromXml<T>(string xml) where T : class
        {
            object value = marshaller.FromXml(xml, context);
            if (value is GenericObjectHolder) value = ((GenericObjectHolder) value).Value;
            return value as T;
        }

        public void Alias<T>(string alias)
        {
            context.Alias(alias,typeof(T));
        }        
    }
}