using System;
using NUnit.Framework;
using Xstream.Core.Converters;
using Xstream.Tests;

namespace Xstream.Converters
{
	[TestFixture]
	public class TestCharConverter : BasePrimitiveTest
	{
		[TestFixtureSetUp]
		public void SetUp()
		{
			xmlName			= "char";
			shortType		= typeof( char );
			clrType			= typeof( System.Char );
			converterType	= typeof( CharConverter );
		}

		[Test]
		public void TestSerializeArray()
		{
			char[] array	= { TestRandomizer.GetChar(), TestRandomizer.GetChar(), TestRandomizer.GetChar(), 
								  TestRandomizer.GetChar(), TestRandomizer.GetChar(), TestRandomizer.GetChar() };

			string xml		= xstream.ToXml( array );
			char[] reverse	= xstream.FromXml( xml ) as char[];

			Assert.IsNotNull( reverse );
			Assert.AreEqual( array, reverse );
		}

		[Test]
		public void TestArrayRepetitive()
		{
			for ( int i = 0; i < 100; i++ )
				TestSerializeArray();
		}

		protected override object GetValue()
		{
			return TestRandomizer.GetChar();
		}
	}
}
