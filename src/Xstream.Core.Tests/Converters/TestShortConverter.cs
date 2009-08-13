using System;
using NUnit.Framework;
using Xstream.Core.Converters;
using Xstream.Core.Tests;
using Xstream.Core.Tests.Converters;

namespace Xstream.Converters
{
	[TestFixture]
	public class TestShortConverter : BasePrimitiveTest
	{
		[TestFixtureSetUp]
		public void SetUp()
		{
			xmlName			= "short";
			shortType		= typeof( short );
			clrType			= typeof( System.Int16 );
			converterType	= typeof( ShortConverter );
		}

		protected override object GetValue()
		{
			return TestRandomizer.GetShort();
		}
	}
}
