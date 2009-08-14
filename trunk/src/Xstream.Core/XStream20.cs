using System;
using System.Collections;

namespace Xstream.Core
{
    public class XStream<TypeOfRoot> : XStream
    {
        public XStream()
        {
            AutoAlias(typeof(TypeOfRoot));
        }
    }

    /// <summary>
    /// Easy facade class used to (de)serialize objects to and from XML.
    /// This class uses a default MarshalContext that is capable of (de)
    /// serializing almost all objects.
    /// </summary>
    public partial class XStream
    {
        protected IMarshalContext context;
        private readonly XStreamMarshaller marshaller;

        private XStream(MarshalContext context)
        {
            this.context = context;
            marshaller = new XStreamMarshaller();
            Alias("GenericHolder", typeof (GenericObjectHolder));
        }

        public XStream()
            : this(new MarshalContext())
        {
        }

        public XStream(IEqualityComparer equalityComparer)
            : this(new MarshalContext(equalityComparer))
        {
        }

        public bool CaseSensitive
        {
            get { return context.CaseSensitive; }
            set { context.CaseSensitive = value; }
        }

        public XStream AutoAlias<TypeOfRoot>()
        {
            return AutoAlias(typeof (TypeOfRoot));            
        }

        internal XStream AutoAlias(Type TypeOfRoot)
        {
            string root_namespace = TypeOfRoot.Namespace;
            foreach (Type t in TypeOfRoot.Assembly.GetTypes())
            {
                if (t.Namespace.StartsWith(root_namespace))
                {
                    Alias(t.FullName.Replace(root_namespace+".", ""), t);
                }
            }
            return this;
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
        [Obsolete]
        public virtual object FromXml(string xml)
        {
            object value = marshaller.FromXml(xml, context);
            if (value is GenericObjectHolder) value = ((GenericObjectHolder)value).Value;
            return value;
        }

        /// <summary>
        /// Adds a simple string alias for a specific Type.
        /// </summary>
        /// <param name="alias">String alias name.</param>
        /// <param name="type">Type to use the alias for.</param>
        [Obsolete]
        public XStream Alias(string alias, Type type)
        {
            context.Alias(alias, type);
            return this;
        }

        public XStream AddIgnoreAttribute(Type ignoredAttributeType)
        {
            context.AddIgnoreAttribute(ignoredAttributeType);
            return this;
        }

        public XStream AddConverter(IConverter converter)
        {
            context.AddConverter(converter);
            return this;
        }

        public XStream AddCData(Type type, string name)
        {
            context.AddCdata(type, name);
            return this;
        }
        public virtual T FromXml<T>(string xml) where T : class
        {
            object value = marshaller.FromXml(xml, context);
            if (value is GenericObjectHolder) value = ((GenericObjectHolder) value).Value;
            return value as T;
        }

        public XStream Alias<T>(string alias)
        {
            context.Alias(alias,typeof(T));
            return this;
        }        
    }
}