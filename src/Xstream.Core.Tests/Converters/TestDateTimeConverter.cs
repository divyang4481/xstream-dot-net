using System;
using NUnit.Framework;

namespace Xstream.Core.Tests.Converters
{
    [TestFixture]
    public class TestDateTimeConverter : BaseTest
    {
        [Test]
        public void TestSerialize()
        {
            DateTime now		= DateTime.Now;
            now.AddSeconds( TestRandomizer.GetDouble() );
            now.AddDays( TestRandomizer.GetShort() );

            string xml			= xstream.ToXml( now );
            DateTime reverse	= (DateTime) xstream.FromXml( xml );

            Assert.AreEqual( now, reverse );
        }
    }
}