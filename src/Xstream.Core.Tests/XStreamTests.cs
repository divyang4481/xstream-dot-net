using NUnit.Framework;
using Xstream.Core.Converters.Collections;

namespace Xstream.Core.Tests
{
    internal class XStreamTests
    {
        [TestFixture]
        public class when_using_a_generic_alias
        {
            private TestPerson person;
            private TestPerson actual;
            
            public void arrange()
            {
                person = new TestPerson();
                person.ID = 12;
            }

            public void act()
            {
                XStream xs = new XStream();
                xs.Alias<TestPerson>("person");
                string xml = xs.ToXml(person);
                actual = xs.FromXml(xml) as TestPerson;            
            }        

            [Test]
            public void should_serialize_and_deserialize()
            {
                arrange();
                act();
                Assert.IsNotNull(actual);
                Assert.AreEqual(person.ID,actual.ID);
            }
        }

        [TestFixture]
        public class when_using_a_generic_FromXML
        {
            private TestPerson person;
            private TestPerson actual;
            
            public void arrange()
            {
                person = new TestPerson();
                person.ID = 12;
            }

            public void act()
            {
                XStream xs = new XStream();
                xs.Alias("person",typeof(TestPerson));
                string xml = xs.ToXml(person);
                actual = xs.FromXml<TestPerson>(xml);            
            }        

            [Test]
            public void should_serialize_and_deserialize()
            {
                arrange();
                act();
                Assert.IsNotNull(actual);
                Assert.AreEqual(person.ID,actual.ID);
            }
        }
    }
}