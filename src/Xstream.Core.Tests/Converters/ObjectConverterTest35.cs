using System;
using NUnit.Framework;
using Xstream.Core.Tests.Converters.Collections;

namespace Xstream.Core.Tests.Converters
{
    internal class ObjectConverterTest35
    {
        [TestFixture]
        public class when_an_auto_property_is_null : BaseTest
        {
            [Test]
            public void should_generate_a_null_xml_property()
            {
                TestEvent35 expected = new TestEvent35();
                expected.Start = new DateTime(1981, 4, 1);

                xstream.Alias<TestEvent35>("event");
                string xml = xstream.ToXml(expected);
                Console.WriteLine(xml);
                var actual = xstream.FromXml<TestEvent35>(xml);

                Assert.IsNull(actual.Creator);
            }
        }
        
    }
}