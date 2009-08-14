using System;
using System.Xml;

namespace Xstream.Core
{
    public class XStream<TypeOfRoot> : XStreamBase where TypeOfRoot : class
    {
        public XStream()
        {
            AutoAlias(typeof(TypeOfRoot));
        }        

        public TypeOfRoot FromXml(string xml)
        {
            return base.FromXml<TypeOfRoot>(xml);
        }

        public string ToXml(TypeOfRoot entity)
        {
            return base.ToXml(entity);
        }
        public XStream<TypeOfRoot> AddIgnoreAttribute(Type ignoredAttributeType)
        {
            return base.AddIgnoreAttribute(ignoredAttributeType) as XStream<TypeOfRoot>;
        }

        public XStream<TypeOfRoot> AddConverter(IConverter converter)
        {
            return base.AddConverter(converter) as XStream<TypeOfRoot>;
        }

        public XStream<TypeOfRoot> AddCData<T>(string property_name)
        {
            return base.AddCData<T>(property_name) as XStream<TypeOfRoot>;
        }

        public XStream<TypeOfRoot> Alias<T>(string alias)
        {
            return base.Alias<T>(alias) as XStream<TypeOfRoot>;
        }
        
        public XStream<TypeOfRoot> ValidateDTD(string dtd)
        {
            return base.ValidateDTD(dtd) as XStream<TypeOfRoot>;
        }
    }

    /// <summary>
    /// Easy facade  class used to (de)serialize objects to and from XML.
    /// This class uses a default MarshalContext that is capable of (de)
    /// serializing almost all objects.
    /// </summary>
    public partial class XStream : XStreamBase
    {

        /// <summary>
        /// Converts the xml string parameter back to a class instance.
        /// </summary>
        [Obsolete]
        public virtual object FromXml(string xml)
        {
            if (base.dtd_for_validation != string.Empty) validate_string(dtd_for_validation + xml);
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

        public string ToXml(object value)
        {
            return base.ToXml(value);
        }

        public XStream AutoAlias<TypeOfRoot>()
        {
            return base.AutoAlias<TypeOfRoot>() as XStream;
        }

        public XStream AddIgnoreAttribute(Type ignoredAttributeType)
        {
            return base.AddIgnoreAttribute(ignoredAttributeType) as XStream;                        
        }

        public XStream AddConverter(IConverter converter)
        {
            return base.AddConverter(converter) as XStream;            
        }

        public XStream AddCData<T>(string property_name)
        {
            return base.AddCData<T>(property_name) as XStream;
        }

        public XStream Alias<T>(string alias)
        {
            return base.Alias<T>(alias) as XStream;
        }
        public XStream ValidateDTD(string dtd)
        {
            return base.ValidateDTD(dtd) as XStream;
        }

        public T FromXml<T>(string xml) where T : class
        {
            return base.FromXml<T>(xml);
        }

    }
}