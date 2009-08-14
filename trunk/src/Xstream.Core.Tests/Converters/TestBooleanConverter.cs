using System;
using NUnit.Framework;
using Xstream.Core.Converters;

namespace Xstream.Core.Tests.Converters
{
    [TestFixture]
    public class TestBooleanConverter : BasePrimitiveTest
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            xmlName			= "bool";
            shortType		= typeof( bool );
            clrType			= typeof( System.Boolean );
            converterType	= typeof( BooleanConverter );
        }

        protected override object GetValue()
        {
            return TestRandomizer.GetBool();
        }
    }
}