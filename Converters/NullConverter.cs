using System;
using System.Reflection;
using System.Xml;

namespace Xstream.Core.Converters
{
	/// <summary>
	/// Special converter to convert null values.
	/// </summary>
	public class NullConverter : IConverter
	{
		private static readonly Type __type = typeof( NullType );

		/// <summary>
		/// Register is called by a MarshalContext to allow the
		/// converter instance to register itself in the context
		/// with all appropriate value types and interfaces.
		/// </summary>
		public void Register( MarshalContext context )
		{
			context.RegisterConverter( __type, this );
			context.Alias( "null", __type );
		}

		/// <summary>
		/// Converts the object passed in to its XML representation.
		/// The XML string is written on the XmlTextWriter.
		/// </summary>
		public void ToXml( object value, FieldInfo field, XmlTextWriter xml, MarshalContext context )
		{
			xml.WriteElementString( "null", string.Empty );
		}

		/// <summary>
		/// Converts the XmlNode data passed in back to an actual
		/// .NET instance object.
		/// </summary>
		/// <returns>Object created from the XML.</returns>
		public object FromXml( object parent, FieldInfo field, Type type, XmlNode xml, MarshalContext context )
		{
			return null;
		}
	}
}
