using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Xstream.Core.Tests.Converters.Collections
{
    [TestFixture]
    public class TestGetterSetter35
    {
        [Test]
        public void should_be_able_to_get_properties()
        {
            int id = 2;
            XStream xs = new XStream();
            xs.Alias<TestPerson35>("person");
            var person = new TestPerson35 {ID = id};            
            string xml = xs.ToXml(person);
            Assert.IsTrue(xml.Contains("<ID>2</ID>"));
        }

        [Test]
        public void should_be_able_to_use_a_setter_property()
        {
            string xml = "<person><ID>2</ID></person>";
 
            XStream xs = new XStream();
            xs.Alias<TestPerson35>("person");
            var person = xs.FromXml<TestPerson35>(xml);
            Assert.AreEqual(2, person.ID);
        }
    }
}