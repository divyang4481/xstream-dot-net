using System;
using NUnit.Framework;
using Xstream.Core.Converters;
using Xstream.Tests;

namespace Xstream.Converters
{
	[TestFixture]
	public class TestFloatConverter : BasePrimitiveTest
	{
	    private static readonly float delta = 0.0000001f;

		[TestFixtureSetUp]
		public void SetUp()
		{
			xmlName			= "float";
			shortType		= typeof( float );
			clrType			= typeof( Single );
			converterType	= typeof( FloatConverter );
		}

		[Test]
		public void TestRepetitive()
		{
			for (int i = 0; i < 100; i++ )
				TestConversion();
		}


	    protected override void AssertEquality(object value, object rvalue)
	    {
            Assert.AreEqual((float)value, (float)rvalue, delta);
	    }

	    protected override object GetValue()
		{
			return TestRandomizer.GetFloat();
		}
	}
}
