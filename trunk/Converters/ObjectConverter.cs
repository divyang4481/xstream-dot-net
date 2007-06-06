using System;
using System.Collections;
using System.Reflection;
using System.Xml;

namespace Xstream.Core.Converters
{
    /// <summary>
    /// Converts a custom object to xml and back.
    /// </summary>
    public class ObjectConverter : IConverter
    {
        private static readonly Type __type = typeof (object);

        private static readonly BindingFlags __flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                                                       BindingFlags.FlattenHierarchy | BindingFlags.DeclaredOnly;

        /// <summary>
        /// Register is called by a MarshalContext to allow the
        /// converter instance to register itself in the context
        /// with all appropriate value types and interfaces.
        /// </summary>
        public void Register(MarshalContext context)
        {
            context.RegisterConverter(__type, this);
        }

        /// <summary>
        /// Converts the object passed in to its XML representation.
        /// The XML string is written on the XmlTextWriter.
        /// </summary>
        public void ToXml(object value, FieldInfo field, XmlTextWriter xml, MarshalContext context)
        {
            Type type = value != null ? value.GetType() : null;

            if (typeof (MulticastDelegate).IsAssignableFrom(type))
                return;

            // If dynamic type, use the base type instead
            if (type.ToString().StartsWith(DynamicInstanceBuilder.__typePrefix))
                type = type.BaseType;

            context.WriteStartTag(type, field, xml);
            WriteAfterStartTag(value, field, xml, context, type);
        }

        public void WriteAfterStartTag(object value, FieldInfo field, XmlTextWriter xml, MarshalContext context, Type type)
        {
            int stackIx = context.GetStackIndex(value);

            if (stackIx >= 0)
                xml.WriteAttributeString("ref", stackIx.ToString());
            else
            {
                context.Stack(value, type);

                if (value != null)
                    ToXmlAs(context, type, value, xml);
            }

            context.WriteEndTag(type, field, xml);
        }

        private bool ShouldIgnore(FieldInfo fieldInfo, Type type)
        {
            object[] attributes = fieldInfo.GetCustomAttributes(true);
            foreach (Attribute attribute in attributes)
            {
                if (attribute.GetType().Equals(type))
                    return true;
            }
            return false;
        }

        private void ToXmlAs(MarshalContext context, Type type, object value, XmlTextWriter xml)
        {
            // Get all the fields of the object
            FieldInfo[] fields = GetFields(type, value);

            // Serialize all fields
            foreach (FieldInfo objectField in fields)
            {
                if (ShouldIgnore(objectField, context.IgnoredAttributeType))
                {
                    AddNullValue(objectField, xml);
                    continue;
                }
                try
                {
                    object fieldValue = objectField.GetValue(value);
                    if (fieldValue != null && fieldValue.GetType().Name.StartsWith("CProxyType") && !fieldValue.GetType().Name.Contains("Hibernate"))
                    {
                        objectField.SetValue(value, null, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance |
                                                          BindingFlags.DeclaredOnly, null, null);
                        fieldValue = null;
                    }

                    if (fieldValue != null)
                    {
                        IConverter converter = context.GetConverter(fieldValue.GetType());
                        converter.ToXml(fieldValue, objectField, xml, context);
                    }
                    else
                        AddNullValue(objectField, xml);
                }
                catch (Exception e)
                {
                    throw new ApplicationException("Couldn't set field " + objectField.Name + " in object " + value + ": " + e.Message, e);
                }
            }
            if (type != typeof (object))
                ToXmlAs(context, type.BaseType, value, xml);
        }

        protected virtual FieldInfo[] GetFields(Type type, object value)
        {
            return type.GetFields(__flags);
        }

        private void AddNullValue(FieldInfo field, XmlTextWriter xml)
        {
            xml.WriteStartElement(field.Name);
            xml.WriteAttributeString("null", true.ToString());
            xml.WriteEndElement();
        }

        /// <summary>
        /// Converts the XmlNode data passed in back to an actual
        /// .NET instance object.
        /// </summary>
        /// <returns>Object created from the XML.</returns>
        public object FromXml(object parent, FieldInfo field, Type type, XmlNode xml, MarshalContext context)
        {
            object value = null;

            if (xml.Attributes["ref"] != null)
            {
                int stackIx = int.Parse(xml.Attributes["ref"].Value);
                value = context.GetStackObject(stackIx);
            }
            else
            {
                try
                {
                    if (value == null)
                    {
                        // Check if there is a parameterless constructor
                        if (type.IsValueType || type.GetConstructor(__flags, null, new Type[0], null) != null)
                            value = Activator.CreateInstance(type, true);
                        else
                            value = DynamicInstanceBuilder.GetDynamicInstance(type);
                    }
                }
                catch (Exception e)
                {
                    throw new ConversionException("Error constructing type: " + type, e);
                }

                // Add the object to the stack
                context.Stack(value, type, xml);

                // Create a map of all fields
                FromXmlAs(context, type, value, xml);
            }
            return value;
        }

        private static void FromXmlAs(MarshalContext context, Type type, object value, XmlNode xml)
        {
            FieldInfo[] fields = type.GetFields(__flags);
            Hashtable fieldMap = new Hashtable(fields.Length);

            foreach (FieldInfo objectField in fields)
                fieldMap[objectField.Name] = objectField;

            // Handle all fields
            foreach (XmlNode child in xml.ChildNodes)
            {
                FieldInfo objectField = fieldMap[child.Name] as FieldInfo;
                if (objectField == null) continue;
                if (child.Attributes["null"] != null)
                {
                    objectField.SetValue(value, null);
                    continue;
                }
                Type objectFieldType = objectField.FieldType;
                IConverter converter = context.GetConverter(child, ref objectFieldType);
                try
                {
                    objectField.SetValue(value, converter.FromXml(value, objectField, objectFieldType, child, context));
                }
                catch (Exception e)
                {
                    throw new ApplicationException("Couldn't set field " + objectField.Name + " in object " + ": " + e.Message, e);
                }
            }
            if (type != typeof (object))
                FromXmlAs(context, type.BaseType, value, xml);
        }
    }
}