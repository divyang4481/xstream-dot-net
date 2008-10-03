using System;
using System.Reflection;
using System.Xml;

namespace Xstream.Core
{
    public interface IMarshalContext
    {
        bool ContainsType(object o);
        object GetOfType(object matchingObj);
        void WriteStartTag(Type type, FieldInfo field, XmlTextWriter textWriter);
        int GetStackIndex(object value);
        void Stack(object value, Type type);
        void WriteEndTag(Type type, FieldInfo field, XmlTextWriter xml);
        object GetStackObject(int stackIx);
        void Stack(object value, Type type, XmlNode xmlNode);
        IConverter GetConverter(XmlNode child, ref Type type);
        void RegisterConverter(Type type, IConverter converter);
        Type IgnoredAttributeType { get; }
        IConverter GetConverter(Type type);
        void ClearStack();
        void Alias(string s, Type type);
        void Stack(object o);
        void AddIgnoreAttribute(Type type);
        string GetTypeName(Type type);
        void AddConverter(IConverter converter);
    }
}