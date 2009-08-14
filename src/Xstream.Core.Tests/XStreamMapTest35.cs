using NUnit.Framework;
using Xstream.Core.Tests.Converters;
using Xstream.Core.Tests.Converters.Collections;

namespace Xstream.Core.Tests
{
    public class XStreamMapTest35
    {
        [TestFixture]
        public class when_using_a_map_of_classes_in_the_same_name_space : BaseTest
        {
            [Test]
            public void should_serialize_without_the_full_class_name()
            {
                var map = new XStream();
                var xml = map.ToXml(new TestArray35 {people = new[] {new TestPerson35{ID=12,Name="Joe"}}});
                Assert.AreEqual("", xml);

            }
        }
    }
}