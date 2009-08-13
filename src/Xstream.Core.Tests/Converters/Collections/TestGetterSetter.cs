using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Xstream.Core.Converters.Collections
{
    [TestFixture]
    public class TestGetterSetter
    {
        [Test]
        public void should_be_able_to_get_properties()
        {
            int id = 2;
            XStream xs = new XStream();
            xs.Alias("person", typeof(TestPerson));
            string xml = xs.ToXml(new TestPerson { ID = id });
            Assert.IsTrue(xml.Contains("<ID>2</ID>"));
        }

        [Test]
        public void should_be_able_to_use_a_setter_property()
        {
            string xml = "<person><ID>2</ID></person>";
 
            XStream xs = new XStream();
            xs.Alias("person", typeof(TestPerson));
            TestPerson person = xs.FromXml(xml) as TestPerson;
            Assert.AreEqual(2, person.ID);
        }
    }
}
