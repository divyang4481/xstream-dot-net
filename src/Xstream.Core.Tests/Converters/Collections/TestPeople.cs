using System.Collections.Generic;

namespace Xstream.Core.Tests.Converters.Collections
{
    internal class TestPeople
    {
        //private TestPerson[] _people1;
        List<TestPerson> _people = new List<TestPerson>();

        /*public TestPerson[] people1
        {
            get { return _people1; }
            set { _people1 = value; }
        }*/
        public List<TestPerson> people
        {
            get { return _people; }
            set { _people = value; }
        }
    }
}