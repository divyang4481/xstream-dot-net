using NUnit.Framework;
using Xstream.Core;
using Xstream.Tests;

namespace Xstream.Converters
{
    [TestFixture]
    public class TestArrayConverter
    {
        private XStream xstream;

        [SetUp]
        public void Init()
        {
            xstream = new XStream();
        }

        [Test]
        public void TestStringArrayWithNull()
        {
            string[] a = {TestRandomizer.GetString(), TestRandomizer.GetString(), null, TestRandomizer.GetString()};

            string xml = xstream.ToXml(a);
            string[] rev = xstream.FromXml(xml) as string[];

            Assert.IsNotNull(rev);
            Assert.AreEqual(a, rev);
        }

        [Test]
        public void TestIntArray()
        {
            int[] a = {
                          TestRandomizer.GetInt(), TestRandomizer.GetInt(), TestRandomizer.GetInt(), TestRandomizer.GetInt(), TestRandomizer.GetInt(),
                          TestRandomizer.GetInt()
                      };

            string xml = xstream.ToXml(a);
            int[] rev = xstream.FromXml(xml) as int[];

            Assert.IsNotNull(rev);
            Assert.AreEqual(a, rev);
        }

        [Test]
        public void TestObjectArray()
        {
            TestObject[] a = {new TestObject(), new TestObject(), new TestObject()};

            string xml = xstream.ToXml(a);
            TestObject[] rev = xstream.FromXml(xml) as TestObject[];

            Assert.IsNotNull(rev);
            Assert.AreEqual(a, rev);
        }

        [Test]
        public void TestStructArray()
        {
            TestStruct s1 = new TestStruct();
            s1.Int = TestRandomizer.GetInt();
            s1.String = TestRandomizer.GetString();

            TestStruct[] a = {s1, new TestStruct(), new TestStruct(null)};

            string xml = xstream.ToXml(a);
            TestStruct[] rev = xstream.FromXml(xml) as TestStruct[];

            Assert.IsNotNull(rev);
            Assert.AreEqual(a, rev);
        }

        [Test]
        public void TestObjectArrayMember()
        {
            object[] array = new object[] {TestRandomizer.GetString(), TestRandomizer.GetInt(), TestRandomizer.GetDecimal()};

            ArrayHolder ah = new ArrayHolder();
            ah.RandomNumber = TestRandomizer.GetInt();
            ah.Array = array;

            string xml = xstream.ToXml(ah);
            ArrayHolder ahRev = xstream.FromXml(xml) as ArrayHolder;

            Assert.IsNotNull(ahRev);
            Assert.AreEqual(ah.RandomNumber, ahRev.RandomNumber);
            Assert.AreEqual(ah.Array, ahRev.Array);
        }

        private class TestObject
        {
            private int _Int;
            private string _String;

            public TestObject()
            {
                _Int = TestRandomizer.GetInt();
                _String = TestRandomizer.GetString();
            }

            public override bool Equals(object obj)
            {
                TestObject o = obj as TestObject;
                return o._Int == _Int && o._String == _String;
            }

            public override int GetHashCode()
            {
                return _Int + 29*(_String != null ? _String.GetHashCode() : 0);
            }
        }

        private struct TestStruct
        {
            public int Int;
            public string String;

            public TestStruct(object dummy)
            {
                Int = TestRandomizer.GetInt();
                String = TestRandomizer.GetString();
            }
        }

        private class ArrayHolder
        {
            private int _RandomNumber;
            private object[] _Array;

            public int RandomNumber
            {
                get { return _RandomNumber; }
                set { _RandomNumber = value; }
            }

            public object[] Array
            {
                get { return _Array; }
                set { _Array = value; }
            }
        }
    }
}