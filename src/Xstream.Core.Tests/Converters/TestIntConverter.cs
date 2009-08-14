using System;
using NUnit.Framework;
using Xstream.Core.Converters;

namespace Xstream.Core.Tests.Converters
{
    [TestFixture]
    public class TestIntConverter : BasePrimitiveTest
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            xmlName			= "int";
            shortType		= typeof( int );
            clrType			= typeof( Int32 );
            converterType	= typeof( IntConverter );
        }

        protected override object GetValue()
        {
            return TestRandomizer.GetInt();
        }
    }
}