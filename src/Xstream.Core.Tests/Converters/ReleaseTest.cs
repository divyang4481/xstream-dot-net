using System;
using System.Collections.Generic;
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
            List<Type> entryPoints = new List<Type>(new Type[] {typeof (XStream), typeof (FileXStream)});
            foreach (Type type in types)
            {
                if (!IsTextFixture(type) && !type.IsInterface && !entryPoints.Contains(type) && !type.IsAssignableFrom(typeof (ConversionException)))
                    Assert.AreEqual(false, type.IsVisible, type + " is not internal");
            }
            entryPoints.ForEach(delegate(Type obj) { Assert.AreEqual(true, obj.IsVisible, string.Format("Type: {0} is not visible", obj)); });
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