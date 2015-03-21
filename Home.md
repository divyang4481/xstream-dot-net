## Introduction ##

XStream.Net is the .Net version of **[Joe Walnes' XStream for Java](http://xstream.codehaus.org)**. It is a simple library for serialisation/deserialisation to & from xml. The original code for this project was taken from [Arne Vandamme's weblog](http://www.jroller.com/page/CoBraLorD?entry=net_transparent_xml_serialization_xstream) which was a port of XStream for Java.


## Usage ##
```
string serialisedObject = new XStream().ToXml(originalObject);
object deserialisedObject = new XStream().FromXml(serialisedObject);
Assert.AreEqual(originalObject, deserialisedObject);
```

## Example ##
say you have this class:

```
class SimpleClass
    {
      private int a; 
      private string x; 
    }
```
and you execute this code:
```
    XStream xstream = new XStream(); 
    SimpleClass simp = new SimpleClass(1, 2, "testString");   
    System.Console.WriteLine(xstream.ToXml(simp)); 
```

you get this:

```
<SimpleClass assembly="XstreamTest, Version=1.0.2342.35727, Culture=neutral, PublicKeyToken=null"><a>7</a><x>testString</x></SimpleClass>
```

Now if you add this line:
```
    xstream.Alias("SimpleClass", typeof(SimpleClass));
```
you get:
```
    <SimpleClass?><a>7</a><x>testString</x></SimpleClass?>
```

you are now free to read this class back in like this. (Note: this should work but it doesn't):

```
    string classString = "<SimpleClass><a>1</a><b>2</b><x>testString</x></SimpleClass?>"; 
    XStream xstream = new XStream(); 
    xstream.Alias("SimpleClass", typeof(SimpleClass)); 
    SimpleClass simpRead = xstream.FromXml(classString) as SimpleClass; 
```