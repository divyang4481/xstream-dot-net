using System;
using System.Collections;
using NUnit.Framework;

namespace Xstream.Converters
{
	[TestFixture]
	public class TestTypeConverter : BaseTest
	{
		[Test]
		public void TestSerialize()
		{
			Type t		= new Hashtable().GetType();

			string xml	= xstream.ToXml( t );
			Type r		= xstream.FromXml( xml ) as Type;
			
			Assert.AreEqual( t, r );
		}
	}
}
