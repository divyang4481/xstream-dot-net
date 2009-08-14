using System;
using NUnit.Framework;
using Xstream.Core.Converters;

namespace Xstream.Core.Tests.Converters
{
    [TestFixture]
    public class TestGuidConverter : BasePrimitiveTest
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            xmlName			= "guid";
            shortType		= typeof( Guid );
            clrType			= typeof( Guid );
            converterType	= typeof( GuidConverter );
        }

        protected override object GetValue()
        {
            return TestRandomizer.GetGuid();
        }
    }
}