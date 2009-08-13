using System;
using System.Collections;
using System.Reflection;
using NUnit.Framework;

namespace Xstream.Converters
{
	[TestFixture]
	public class TestMethodInfoConverter : BaseTest
	{
		[Test]
		public void TestSerialize()
		{
			ArrayList list	= new ArrayList();
			
			Type type		= list.GetType();
			MethodInfo info	= type.GetMethod( "Add" );

			string xml		= xstream.ToXml( info );
			MethodInfo rev	= xstream.FromXml( xml ) as MethodInfo;

			Assert.IsNotNull( rev );
			Assert.AreEqual( info, rev );
		}
	}
}
