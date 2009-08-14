using System;
using NUnit.Framework;
using Xstream.Core.Converters;

namespace Xstream.Core.Tests.Converters
{
    [TestFixture]
    public class TestLongConverter : BasePrimitiveTest
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            xmlName			= "long";
            shortType		= typeof( long );
            clrType			= typeof( Int64 );
            converterType	= typeof( LongConverter );
        }

        protected override object GetValue()
        {
            return TestRandomizer.GetLong();
        }
    }
}