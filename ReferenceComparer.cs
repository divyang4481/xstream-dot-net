using System.Collections;

namespace Xstream.Core
{
    public class ReferenceComparer : IEqualityComparer
    {
        bool IEqualityComparer.Equals(object x, object y)
        {
            return ReferenceEquals(x, y);
        }

        int IEqualityComparer.GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }
    }
}