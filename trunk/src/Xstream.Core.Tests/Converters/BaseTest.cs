using NUnit.Framework;

namespace Xstream.Core.Tests.Converters
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected XStream xstream;

        [SetUp]
        public void Init()
        {
            xstream = new XStream();	
        }
    }
}