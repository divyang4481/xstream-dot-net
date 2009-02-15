using System;
using System.Globalization;
using NUnit.Framework;
using Xstream.Tests;

namespace Xstream.Converters
{
	[TestFixture]
	public class TestEnumConverter : BaseTest
	{
		[Test]
		public void TestSerialize()
		{
			RandomEnumForTest re	= TestRandomizer.GetEnum();

			string xml		= xstream.ToXml( re );
			RandomEnumForTest rre	= (RandomEnumForTest) xstream.FromXml( xml );

			Assert.AreEqual( re, rre );
		}
	}
}
