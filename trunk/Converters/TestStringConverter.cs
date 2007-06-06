using System;
using NUnit.Framework;
using Xstream.Core.Converters;
using Xstream.Tests;

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
