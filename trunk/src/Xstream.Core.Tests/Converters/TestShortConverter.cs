using System;
using NUnit.Framework;
using Xstream.Core.Converters;

namespace Xstream.Core.Tests.Converters
{
    [TestFixture]
    public class TestShortConverter : BasePrimitiveTest
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            xmlName			= "short";
            shortType		= typeof( short );
            clrType			= typeof( Int16 );
            converterType	= typeof( ShortConverter );
        }

        protected override object GetValue()
        {
            return TestRandomizer.GetShort();
        }
    }
}