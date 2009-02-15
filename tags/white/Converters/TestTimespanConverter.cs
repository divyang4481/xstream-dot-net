using System;
using NUnit.Framework;
using Xstream.Tests;

namespace Xstream.Converters
{
	[TestFixture]
	public class TestTimespanConverter : BaseTest
	{
		[Test]
		public void TestSerialize()
		{
			TimeSpan span		= TimeSpan.FromTicks( TestRandomizer.GetLong() );
			span.Add( new TimeSpan( 10, 3, 27, 59 ) );

			string xml			= xstream.ToXml( span );
			TimeSpan reverse	= (TimeSpan) xstream.FromXml( xml );

			Assert.AreEqual( span, reverse );
		}
	}
}
