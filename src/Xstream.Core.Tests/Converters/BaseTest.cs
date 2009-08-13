using NUnit.Framework;
using Xstream.Core;

namespace Xstream.Converters
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
