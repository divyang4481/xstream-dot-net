using NUnit.Framework;
using Xstream.Core.Converters.Collections;

namespace Xstream.Converters
{
    internal class ObjectConverterTests
    {
        [TestFixture]
        public class when_case_is_incorrect : BaseTest
        {            
            [Test]
            public void shouldnt_deserialize()
            {
                TestPerson expected = new TestPerson();
                expected.ID = 12;

                xstream.Alias("person", typeof(TestPerson));
                string xml = xstream.ToXml(expected).ToLower();
                TestPerson actual = (TestPerson)xstream.FromXml(xml);

                Assert.AreNotEqual(expected.ID, actual.ID);
            }
        }
        [TestFixture]
        public class when_case_is_incorrect_and_case_insensetive : BaseTest
        {            
            [Test]
            public void shouldnt_deserialize()
            {
                TestPerson expected = new TestPerson();
                expected.ID = 12;

                xstream.Alias("person", typeof(TestPerson));
                xstream.CaseSensitive = false;
                string xml = xstream.ToXml(expected).ToLower();
                TestPerson actual = (TestPerson)xstream.FromXml(xml);

                Assert.AreEqual(expected.ID, actual.ID);
            }
        }
    }
}