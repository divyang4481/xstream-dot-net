using System;
using NUnit.Framework;
using Xstream.Core;
using Xstream.Core.Converters;

namespace Xstream.Converters
{
	[TestFixture]
	public abstract class BasePrimitiveTest
	{
		protected string xmlName;
		protected Type shortType, clrType, converterType;

		protected XStream xstream;

		[SetUp]
		public void Init()
		{
			xstream = new XStream();
		}

		[Test]
		public void TestGetConverter()
		{
			if ( shortType != null && clrType != null )
			{
				MarshalContext ctx	= new MarshalContext();
				IConverter ca		= ctx.GetConverter( shortType );
				IConverter cb		= ctx.GetConverter( clrType );

				Assert.IsNotNull( ca );
				Assert.AreSame( ca, cb );
				Assert.AreEqual( converterType, ca.GetType() );
			}
		}

		[Test]
		public virtual void TestSerialize()
		{
			object value	= GetValue();
	
			string xml		= xstream.ToXml( value );

			Assert.IsNotNull( xml );
			Assert.AreEqual( "<" + xmlName + ">" + value.ToString() + "</" + xmlName + ">", xml );
		}

		[Test]
		public virtual void TestSerializeMapping()
		{
			string alias	= "_testAlias_";
			object value	= GetValue();

			xstream.Alias( alias, shortType );
			string xml		= xstream.ToXml( value );

			Assert.IsNotNull( xml );
			Assert.AreEqual( "<" + alias + ">" + value.ToString() + "</" + alias + ">", xml );
		}

		[Test]
		public virtual void TestDeserialize()
		{
			object value	= GetValue();
			object rvalue	= xstream.FromXml("<" + xmlName + ">" + value + "</" + xmlName + ">" );
			
            AssertEquality(value, rvalue);
		}

		[Test]
		public virtual void TestDeserializeMapping()
		{
			string alias	= "_primitiveAlias_";
			xstream.Alias( alias, shortType );
			
			object value	= GetValue();
			object rvalue	= xstream.FromXml( "<" + alias + ">" + value + "</" + alias + ">" );

            AssertEquality(value, rvalue);
		}

		[Test]
		public void TestConversion()
		{
			object value	= GetValue();
			string xml		= xstream.ToXml( value );
			object rvalue	= xstream.FromXml( xml );

			Assert.IsNotNull( rvalue );
		    AssertEquality(value, rvalue);
		}

	    protected virtual void AssertEquality(object value, object rvalue)
	    {
	        Assert.AreEqual( value, rvalue );
	    }

		protected abstract object GetValue();
	}
    
    [TestFixture]
    public class NoopConverterTest
    {
        [Test]
        public void PredicateShouldGetNoopConverter()
        {
            MarshalContext marshalContext = new MarshalContext();
            IConverter converter = marshalContext.GetConverter(typeof(Predicate<object>));
            Assert.IsNotNull(converter);
            Assert.AreEqual(typeof(NoopConverter), converter.GetType());
        }
    }
}
