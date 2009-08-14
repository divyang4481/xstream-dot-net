using System;
using NUnit.Framework;
using Xstream.Core.Tests.Converters;
using Xstream.Core.Tests.Converters.Collections;

namespace Xstream.Core.Tests
{
    public class XStreamTest35{
        [TestFixture]
        public class when_using_the_auto_alias_of_classes_in_the_same_name_space : BaseTest
        {
            [Test]
            public void should_serialize_without_the_full_class_name()
            {
                var map = new XStream().AutoAlias<TestArray35>();
                var xml = map.ToXml(new TestArray35 {people = new[] {new TestPerson35{ID=12,Name="Joe"}}});
                Assert.AreEqual("<TestArray35><people><TestPerson35><ID>12</ID><Name>Joe</Name></TestPerson35></people></TestArray35>", xml);
            }

            [Test]
            public void should_deserialize()
            {
                var xml = "<TestArray35><people><TestPerson35><ID>12</ID><Name>Joe</Name></TestPerson35></people></TestArray35>";
                var map = new XStream<TestArray35>();
                var actual = map.FromXml(xml);
                Assert.AreEqual(12, actual.people[0].ID);
            }
        }

        [TestFixture]
        public class when_using_a_dtd_to_validate_incoming_xml
        {
            [Test]
            [ExpectedException(typeof(FormatException))]
            public void should_find_an_error()
            {
                string dtd = @"<!DOCTYPE TestPerson35 [
<!ELEMENT TestPerson35 (ID,Nme)>
<!ELEMENT ID (#PCDATA)>
<!ELEMENT Nme (#PCDATA)>
]>";
                string xml = @"<TestPerson35><ID>12</ID><Name>Test</Name></TestPerson35>";
                new XStream<TestPerson35>()
                    .ValidateDTD(dtd)
                    .FromXml(xml);
            }

            [Test]
            public void should_validate()
            {
                string dtd = @"<!DOCTYPE TestPerson35 [
<!ELEMENT TestPerson35 (ID,Name)>
<!ELEMENT ID (#PCDATA)>
<!ELEMENT Name (#PCDATA)>
]>";
                string xml = @"<TestPerson35><ID>12</ID><Name>Test</Name></TestPerson35>";
                new XStream()
                    .AutoAlias<TestPerson35>()
                    .ValidateDTD(dtd)
                    .FromXml(xml);
            }

        }

    }
}