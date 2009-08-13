using System;
using NUnit.Framework;
using Xstream.Core.Converters;
using Xstream.Core.Tests;
using Xstream.Core.Tests.Converters;

namespace Xstream.Converters
{
	[TestFixture]
	public class TestIntConverter : BasePrimitiveTest
	{
		[TestFixtureSetUp]
		public void SetUp()
		{
			xmlName			= "int";
			shortType		= typeof( int );
			clrType			= typeof( System.Int32 );
			converterType	= typeof( IntConverter );
		}

		protected override object GetValue()
		{
			return TestRandomizer.GetInt();
		}
	}
}
