using System;
using System.Collections;
using NUnit.Framework;
using Xstream.Core;
using Xstream.Tests;

namespace Xstream.Converters
{
	[TestFixture]
	public class TestListConverter
	{
		[Test]
		public void TestStreamSimpleArrayList()
		{
			ArrayList list	= new ArrayList(5);
			list.Add( TestRandomizer.GetInt() );
			list.Add( TestRandomizer.GetString() );
			list.Add( TestRandomizer.GetDecimal() );
			list.Add( "last" );
				
			XStream xs		= new XStream();
			string xml		= xs.ToXml( list );

			Assert.IsNotNull( xml );
			Assert.IsTrue( xml.Length > 0 );

			IList rlist		= xs.FromXml( xml ) as IList;

            Assert.IsNotNull( rlist );
			Assert.AreEqual( list.Count, rlist.Count );

			for ( int i = 0; i < list.Count; i++ )
				Assert.AreEqual( list[i], rlist[i] );
		}
	}
}
