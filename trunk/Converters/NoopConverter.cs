using System;
using System.Reflection;
using System.Xml;

namespace Xstream.Core.Converters
{
    public class NoopConverter : IConverter
    {
        private static NoopConverter instance = new NoopConverter();
        private NoopConverter() {}

        public static IConverter Instance
        {
            get { return instance; }
        }

        public void Register(MarshalContext context)
        {
        }

        public void ToXml(object value, FieldInfo field, XmlTextWriter xml, MarshalContext context)
        {
        }

        public object FromXml(object parent, FieldInfo field, Type type, XmlNode xml, MarshalContext context)
        {
            throw new NotImplementedException();
        }
    }
}