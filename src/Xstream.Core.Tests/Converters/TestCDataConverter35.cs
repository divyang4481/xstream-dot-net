using System;
using NUnit.Framework;
using Xstream.Core.Tests.Converters.Collections;

namespace Xstream.Core.Tests.Converters
{
    internal class TestCDataConverter35
    {
        [TestFixture]
        public class when_a_property_is_aliased_as_cdata : BaseTest
        {
            [Test]
            public void should_be_able_to_serialize_and_deserialize()
            {
                TestPerson35 expected = new TestPerson35();
                expected.Name = "John << Doe";
                xstream.Alias<TestPerson35>("person");
                xstream.AddCData<TestPerson35>(x=>x.Name);

                string xml = xstream.ToXml(expected);
                Console.WriteLine(xml);
                TestPerson35 actual = xstream.FromXml<TestPerson35>(xml);

                Assert.IsTrue(xml.Contains("<![CDATA["));
                Assert.AreEqual(expected.Name,actual.Name);
            }
        }

        [TestFixture]
        public class when_a_property_with_a_backing_field_is_aliased_as_cdata : BaseTest
        {
            
        }
       
        [TestFixture]
        public class when_a_property_is_not_set_for_cdata : BaseTest
        {
            [Test]
            public void shouldnt_have_cdata_in_the_xml()
            {
                TestPerson expected = new TestPerson();
                expected.Name = "John << Doe";
                xstream.Alias<TestPerson>("person");

                string xml = xstream.ToXml(expected);
                Console.WriteLine(xml);
                TestPerson actual = xstream.FromXml<TestPerson>(xml);

                Assert.IsFalse(xml.Contains("<![CDATA["));
                Assert.AreEqual(expected.Name, actual.Name);
            }
        }
    }
}