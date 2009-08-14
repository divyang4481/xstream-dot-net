using NUnit.Framework;

namespace Xstream.Core.Tests.Converters
{
    [TestFixture]
    public class TestEnumConverter : BaseTest
    {
        [Test]
        public void TestSerialize()
        {
            RandomEnumForTest re	= TestRandomizer.GetEnum();

            string xml		= xstream.ToXml( re );
            RandomEnumForTest rre	= (RandomEnumForTest) xstream.FromXml( xml );

            Assert.AreEqual( re, rre );
        }
    }
}