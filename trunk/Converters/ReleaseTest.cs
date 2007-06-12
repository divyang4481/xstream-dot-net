using System;
using System.Reflection;
using NUnit.Framework;

namespace Xstream.Core.Converters
{
    [TestFixture]
    public class ReleaseTest
    {
        [Test]
        public void AllMethodsAreVirtual()
        {
            Assembly assembly = Assembly.GetAssembly(GetType());
            Type[] types = assembly.GetTypes();
            Type entryPoint = assembly.GetType("Xstream.Core.XStream");
            foreach (Type type in types)
            {
                if (!IsTextFixture(type) && !type.IsInterface && !type.Equals(entryPoint))
                    Assert.AreEqual(false, type.IsVisible, type + " is not internal");
            }
            Assert.AreEqual(true, entryPoint.IsVisible);
        }

        private static bool IsTextFixture(Type type)
        {
            object[] attributes = type.GetCustomAttributes(false);
            foreach (object attribute in attributes)
            {
                if (attribute.GetType().IsAssignableFrom(typeof (TestFixtureAttribute)))
                    return true;
            }
            return false;
        }
    }
}