using System;
using NUnit.Framework;
using Xstream.Core.Converters;
using Xstream.Core.Tests;
using Xstream.Core.Tests.Converters;

namespace Xstream.Converters
{
	[TestFixture]
	public class TestBooleanConverter : BasePrimitiveTest
	{
		[TestFixtureSetUp]
		public void SetUp()
		{
			xmlName			= "bool";
			shortType		= typeof( bool );
			clrType			= typeof( System.Boolean );
			converterType	= typeof( BooleanConverter );
		}

		protected override object GetValue()
		{
			return TestRandomizer.GetBool();
		}
	}
}
