using System.Collections.Generic;
using NUnit.Framework;
using Xstream.Core.Tests.Converters.Collections;

namespace Xstream.Core.Tests.Converters
{
    internal class ObjectConverterTest20
    {
        [TestFixture]
        public class when_case_is_incorrect : BaseTest
        {            
            [Test]
            [ExpectedException(typeof(ConversionException))]
            public void shouldnt_deserialize()
            {
                int expected = 12;
                string xml = "<Person><ID>"+expected+"</ID></Person>";
                xstream.Alias("person", typeof (TestPerson));
                TestPerson actual = (TestPerson)xstream.FromXml(xml);
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

        [TestFixture]
        public class when_converting_a_generic
        {
            protected XStream xstream;

            [SetUp]
            public void Init()
            {
                xstream = new XStream();
            }

            [Test]
            [Ignore("this isn't working yet")]
            public void TestConvertGeneric()
            {
                List<string> o = new List<string>();
                o.Add("Foo");
                string xml = xstream.ToXml(o);
                o = (List<string>)xstream.FromXml(xml);

                Assert.AreEqual(1, o.Count);
                Assert.AreEqual("Foo", o[0]);
            }

            [Test]
            [Ignore("this isn't working yet")]
            public void ConvertCustomGenericObject()
            {
                GenericObject<string> genericObject = new GenericObject<string>();
                genericObject.Value = "Foo";

                string xml = xstream.ToXml(genericObject);
                genericObject = (GenericObject<string>)xstream.FromXml(xml);

                Assert.AreEqual("Foo", genericObject.Value);
            }

            public class GenericObject<T>
            {
                private T value;

                public T Value
                {
                    get { return value; }
                    set { this.value = value; }
                }
            }
        }
    }
}