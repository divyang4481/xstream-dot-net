using System.Collections.Generic;

namespace Xstream.Core.Tests.Converters.Collections
{
    internal class TestPeople
    {
        List<TestPerson> _people =new List<TestPerson>();
        
        public List<TestPerson> people
        {
            get { return _people; }
            set { _people = value; }
        }
    }
}