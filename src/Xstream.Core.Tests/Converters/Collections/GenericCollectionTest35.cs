using System.Collections.Generic;
using NUnit.Framework;

namespace Xstream.Core.Tests.Converters.Collections
{
    public class GenericCollectionTest35
    {
        [TestFixture]
        public class when_converting_a_List
        {
            [Test]
            public void should_serialize_a_generic_list()
            {
                XStream xs = new XStream();
                xs.Alias<TestPeople35>("TestPeople");
                xs.Alias<TestPerson35>("TestPerson");
                TestPeople35 ppl = new TestPeople35();
                TestPerson35 person = new TestPerson35();
                person.ID = 12;
                person.Name = "Joe";
                ppl.People.Add(person);
                //ppl.people1 = new[] {person};

                string xml = xs.ToXml(ppl);
                Assert.AreEqual("<TestPeople><People><TestPerson><ID>12</ID><Name>Joe</Name></TestPerson></People></TestPeople>", xml);
            }

            [Test]
            public void should_deserialize_a_generic_list()
            {
                string xml = "<TestPeople><People><TestPerson><ID>12</ID><Name>Joe</Name></TestPerson></People></TestPeople>";
                XStream xs = new XStream();
                xs.Alias<TestPeople35>("TestPeople");
                xs.Alias<TestPerson35>("TestPerson");

                TestPeople35 value = xs.FromXml<TestPeople35>(xml);
                Assert.AreEqual(1, value.People.Count);
            }
        }
    }
}