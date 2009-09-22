using System;
using System.Collections.Generic;
using NUnit.Framework;
using Xstream.Core;
using Xstream.Tests;

namespace Xstream.Converters
{
    [TestFixture]
    internal class TestObjectConverter
    {
        protected XStream xstream;

        [SetUp]
        public void Init()
        {
            xstream = new XStream();
        }

        [Test]
        public void TestSerializeFlat()
        {
            PrimitiveObject oo = new PrimitiveObject();
            string xml = xstream.ToXml(oo);
            PrimitiveObject ob = xstream.FromXml(xml) as PrimitiveObject;

            Assert.IsNotNull(ob);
            ComparePrimitiveObject(oo, ob);
        }

        [Test]
        public void TestConvertGeneric()
        {
            List<string> o = new List<string>();
//            GenericContainerObject o = new GenericContainerObject();
            o.Add("Foo");
            string xml = xstream.ToXml(o);
            o = (List<string>) xstream.FromXml(xml);

            Assert.AreEqual(1, o.Count);
            Assert.AreEqual("Foo", o[0]);
        }

        [Test]
        public void ConvertCustomGenericObject()
        {
            GenericObject<string> genericObject = new GenericObject<string>();
            genericObject.Value = "Foo";

            string xml = xstream.ToXml(genericObject);
            xml = "<a[>/</a[>";
            genericObject = (GenericObject<string>) xstream.FromXml(xml);

            Assert.AreEqual("Foo", genericObject.Value);
        }

        [Test]
        public void TestSerializeNested()
        {
            ChildObject oo = new ChildObject();
            string xml = xstream.ToXml(oo);
            ChildObject ob = xstream.FromXml(xml) as ChildObject;

            Assert.IsNotNull(ob);
            Assert.IsNull(ob.Null);
            Assert.IsNotNull(ob.Private);
            Assert.IsNotNull(ob.Public);

            ComparePrimitiveObject(oo.Public, ob.Public);
            ComparePrimitiveObject(oo.Private, ob.Private);
        }

        [Test]
        public void TestSerializeBadConstructor()
        {
            DateTime time = TestRandomizer.GetDateTime();
            ConstructObject o = new ConstructObject(time);

            string xml = xstream.ToXml(o);
            ConstructObject oo = xstream.FromXml(xml) as ConstructObject;

            Assert.AreEqual(o.Created, oo.Created);

            string xml2 = xstream.ToXml(oo);

            Assert.IsNotNull(xml2);
            Assert.AreEqual(xml, xml2);

            ConstructObject ro = xstream.FromXml(xml2) as ConstructObject;
            Assert.AreEqual(oo.Created, ro.Created);
        }

        [Test]
        public void TestSerializeBackReference()
        {
            ChainObject head = new ChainObject(null);
            ChainObject body = new ChainObject(head);
            ChainObject tail = new ChainObject(body);

            head.Append(body);
            body.Append(tail);

            string xml = xstream.ToXml(head);
            ChainObject chain = xstream.FromXml(xml) as ChainObject;
            ChainObject next = chain.Next;

            Assert.IsNotNull(chain);
            Assert.AreEqual(head.Title, chain.Title);
            Assert.IsNull(chain.BackRef);
            Assert.IsNotNull(next);
            Assert.AreEqual(body.Title, next.Title);
            Assert.IsNotNull(next.BackRef);
            Assert.AreEqual(head.Title, next.BackRef.Title);
            Assert.IsNotNull(next.Next);

            chain = next.Next;
            Assert.AreEqual(tail.Title, chain.Title);
            Assert.IsNotNull(chain.BackRef);
            Assert.AreEqual(body.Title, chain.BackRef.Title);
            Assert.IsNull(chain.Next);
        }

        private void ComparePrimitiveObject(PrimitiveObject oa, PrimitiveObject ob)
        {
            Assert.AreEqual(oa.Int, ob.Int);
            Assert.AreEqual(oa.Long, ob.Long);
            Assert.AreEqual(oa.Short, ob.Short);
            Assert.AreEqual(oa.Bool, ob.Bool);
            Assert.AreEqual(oa.String, ob.String);
        }

        public class ConstructObject
        {
            public readonly DateTime Created;

            internal ConstructObject(DateTime created)
            {
                Created = created;
            }
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

        private class ChildObject
        {
            private string _Title;
            private PrimitiveObject _Private;
            private PrimitiveObject _Null;
            public PrimitiveObject Public;

            public ChildObject()
            {
                _Title = TestRandomizer.GetString();
                _Private = new PrimitiveObject();
                Public = new PrimitiveObject();
                _Null = null;
            }

            public PrimitiveObject Private
            {
                get { return _Private; }
            }

            public PrimitiveObject Null
            {
                get { return _Null; }
            }
        }

        private class GenericContainerObject
        {
            private List<string> strings = new List<string>();

            public List<string> Strings
            {
                get { return strings; }
            }
        }

        private class PrimitiveObject
        {
            private int _Int;
            private long _Long;
            private bool _Bool;
            private short _Short;
            private string _String;

            public PrimitiveObject()
            {
                _Int = TestRandomizer.GetInt();
                _Long = TestRandomizer.GetLong();
                _Bool = TestRandomizer.GetBool();
                _Short = TestRandomizer.GetShort();
                _String = TestRandomizer.GetString();
            }

            public int Int
            {
                get { return _Int; }
            }

            public long Long
            {
                get { return _Long; }
            }

            public bool Bool
            {
                get { return _Bool; }
            }

            public short Short
            {
                get { return _Short; }
            }

            public string String
            {
                get { return _String; }
            }
        }

        private class ChainObject
        {
            private string _Title;
            private ChainObject _BackRef;
            private ChainObject _Next;

            private ChainObject()
            {
            }

            public ChainObject(ChainObject backRef)
            {
                _Title = TestRandomizer.GetString();
                _BackRef = backRef;
            }

            public void Append(ChainObject next)
            {
                _Next = next;
            }

            public string Title
            {
                get { return _Title; }
            }

            public ChainObject BackRef
            {
                get { return _BackRef; }
            }

            public ChainObject Next
            {
                get { return _Next; }
            }
        }
    }
}