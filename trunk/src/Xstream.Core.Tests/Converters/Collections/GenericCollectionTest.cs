using System.Collections.Generic;
using NUnit.Framework;

namespace Xstream.Core.Tests.Converters.Collections
{
    public class GenericCollectionTest
    {
        [TestFixture]
        public class when_converting_a_List
        {
            [Test]
            [Ignore("This is not implemented yet, use arrays")]
            public void should_serialize_a_string_list()
            {
                XStream xs = new XStream();
                xs.Alias<TestPerson>("TestPeople");
                xs.Alias<TestPerson>("TestPerson");
                TestPeople ppl = new TestPeople();
                TestPerson person = new TestPerson();
                person.ID = 12;
                person.Name = "Joe";
                ppl.people.Add(person);

                string xml = xs.ToXml(ppl);
                Assert.AreEqual("<TestPeople><TestPerson><ID>12</ID><Name>Joe</Name></TestPerson></TestPeople>", xml);
            }
        }
    }
}