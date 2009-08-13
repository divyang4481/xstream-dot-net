using System;
using NUnit.Framework;
using Xstream.Core.Converters;
using Xstream.Core.Tests;
using Xstream.Core.Tests.Converters;

namespace Xstream.Converters
{
	[TestFixture]
	public class TestStringConverter: BasePrimitiveTest
	{
		[TestFixtureSetUp]
		public void SetUp()
		{
			xmlName			= "string";
			shortType		= typeof( string );
			clrType			= typeof( System.String );
			converterType	= typeof( StringConverter );
		}

		protected override object GetValue()
		{
			return TestRandomizer.GetString();
		}
	}
}
