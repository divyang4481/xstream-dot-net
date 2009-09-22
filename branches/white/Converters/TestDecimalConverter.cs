using System;
using NUnit.Framework;
using Xstream.Core.Converters;
using Xstream.Tests;

namespace Xstream.Converters
{
    [TestFixture]
    public class TestDecimalConverter : BasePrimitiveTest
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            xmlName = "decimal";
            shortType = typeof (decimal);
            clrType = typeof (Decimal);
            converterType = typeof (DecimalConverter);
        }

        protected override object GetValue()
        {
            return TestRandomizer.GetDecimal();
        }

        [Test]
        public void FromXml()
        {
            A a = new A();
            a.b = null;
            Assert.AreEqual(a, xstream.FromXml(xstream.ToXml(a)));
        }

        private class A
        {
            private string a = "a";
            public string b = "b";

            public A()
            {
                a = null;
            }

            public override string ToString()
            {
                return a + " " + b;
            }

            public override int GetHashCode()
            {
                return (a != null ? a.GetHashCode() : 0) + 29 * (b != null ? b.GetHashCode() : 0);
            }

            public override bool Equals(object obj)
            {
                if (this == obj) return true;
                A _a = obj as A;
                if (_a == null) return false;
                if (!Equals(a, _a.a)) return false;
                if (!Equals(b, _a.b)) return false;
                return true;
            }
        }
    }
}