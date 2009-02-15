using System;
using NUnit.Framework;
using Xstream.Core.Converters;
using Xstream.Tests;

namespace Xstream.Converters
{
	[TestFixture]
	public class TestGuidConverter : BasePrimitiveTest
	{
		[TestFixtureSetUp]
		public void SetUp()
		{
			xmlName			= "guid";
			shortType		= typeof( System.Guid );
			clrType			= typeof( System.Guid );
			converterType	= typeof( GuidConverter );
		}

		protected override object GetValue()
		{
			return TestRandomizer.GetGuid();
		}
	}
}
