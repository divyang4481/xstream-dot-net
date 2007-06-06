using System;
using NUnit.Framework;
using Xstream.Core.Converters;
using Xstream.Tests;

namespace Xstream.Converters
{
    [TestFixture]
    public class TestDoubleConverter : BasePrimitiveTest
    {
        private const double delta = 0.000000000000001;

        [TestFixtureSetUp]
        public void SetUp()
        {
            xmlName = "double";
            shortType = typeof (double);
            clrType = typeof (Double);
            converterType = typeof (DoubleConverter);
        }

        [Test]
        public void TestRepetitive()
        {
            for (int i = 0; i < 100; i++)
                TestConversion();
        }

        protected override void AssertEquality(object value, object rvalue)
        {
            Assert.AreEqual((double)value, (double)rvalue, delta);
        }

        [Test]
        public void DoubleToStringAndBack()
        {
            double aDouble = new Random().NextDouble();
            double converterDouble = Convert.ToDouble(aDouble.ToString());
            Assert.AreEqual(aDouble, converterDouble, delta);
        }

        protected override object GetValue()
        {
            return TestRandomizer.GetDouble();
        }
    }
}