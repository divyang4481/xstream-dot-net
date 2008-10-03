using System;
using System.Collections;

namespace Xstream.Core
{
    /// <summary>
    /// Easy facade class used to (de)serialize objects to and from XML.
    /// This class uses a default MarshalContext that is capable of (de)
    /// serializing almost all objects.
    /// </summary>
    public class XStream
    {
        protected IMarshalContext context;
        private readonly XStreamMarshaller marshaller;

        private XStream(MarshalContext context)
        {
            this.context = context;
            marshaller = new XStreamMarshaller();
        }

        public XStream() : this(new MarshalContext())
        {
        }
        
        public XStream(IEqualityComparer equalityComparer) : this(new MarshalContext(equalityComparer))
        {
        }

        /// <summary>
        /// Converts the given object to XML representation.
        /// </summary>
        public virtual string ToXml(object value)
        {
            if (value.GetType().IsGenericType) value = new GenericObjectHolder(value);
            return marshaller.ToXml(value, context);
        }

        /// <summary>
        /// needed since we cannot serialise a generic object at the source
        /// </summary>
        internal class GenericObjectHolder
        {
            public readonly object Value;

            public GenericObjectHolder(object value)
            {
                Value = value;
            }
        }

        /// <summary>
        /// Converts the xml string parameter back to a class instance.
        /// </summary>
        public virtual object FromXml(string xml)
        {
            object value = marshaller.FromXml(xml, context);
            if (value is GenericObjectHolder) value = ((GenericObjectHolder) value).Value;
            return value;
        }

        /// <summary>
        /// Adds a simple string alias for a specific Type.
        /// </summary>
        /// <param name="alias">String alias name.</param>
        /// <param name="type">Type to use the alias for.</param>
        public void Alias(string alias, Type type)
        {
            context.Alias(alias, type);
        }

        public void AddIgnoreAttribute(Type ignoredAttributeType)
        {
            context.AddIgnoreAttribute(ignoredAttributeType);
        }

        public void AddConverter(IConverter converter)
        {
            context.AddConverter(converter);
        }
    }
}