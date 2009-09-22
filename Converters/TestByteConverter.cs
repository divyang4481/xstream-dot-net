using NUnit.Framework;
using Xstream.Core.Converters;
using Xstream.Tests;

namespace Xstream.Converters
{
	[TestFixture]
	public class TestByteConverter : BasePrimitiveTest
	{
		[TestFixtureSetUp]
		public void SetUp()
		{
			xmlName			= "byte";
			shortType		= typeof( byte );
			clrType			= typeof( System.Byte );
			converterType	= typeof( ByteConverter );
		}

		[Test]
		public void TestRepetitive()
		{
			for (int i = 0; i < 100; i++ )
				TestConversion();
		}

		[Test]
		public void TestSerializeArray()
		{
			byte[] array	= TestRandomizer.GetBytes();
			
			string xml		= xstream.ToXml( array );
			byte[] reverse	= xstream.FromXml( xml ) as byte[];

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
			return TestRandomizer.GetBytes()[0];
		}
	}
}
