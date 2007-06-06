namespace Xstream.Core
{
    public interface IMarshalContext
    {
        bool ContainsType(object o);
        object GetOfType(object matchingObj);
    }
}