using System;
using System.IO;
using System.Linq.Expressions;
using System.Xml;
using System.Xml.Schema;

namespace Xstream.Core
{
    /// <summary>
    /// Easy facade class used to (de)serialize objects to and from XML.
    /// This class uses a default MarshalContext that is capable of (de)
    /// serializing almost all objects.
    /// </summary>
    public partial class XStream
    {
        public void AddCData<T>(Expression<Func<T,String>> expression)
        {
            string name = expression.Body.ToString().Replace(expression.Parameters[0].Name + ".", "");
            AddCData<T>(name);
        }

    }
}