using System;
using NUnit.Framework;
using Xstream.Core.Converters;
using Xstream.Tests;

namespace Xstream.Converters
{
	[TestFixture]
	public class TestLongConverter : BasePrimitiveTest
	{
		[TestFixtureSetUp]
		public void SetUp()
		{
			xmlName			= "long";
			shortType		= typeof( long );
			clrType			= typeof( System.Int64 );
			converterType	= typeof( LongConverter );
		}

		protected override object GetValue()
		{
			return TestRandomizer.GetLong();
		}
	}
}
