Xml serialisation for .Net applications

## Introduction ##
XStream.Net is the .Net version of **[Joe Walnes' XStream for Java](http://xstream.codehaus.org)**. It is a simple library for serialisation/deserialisation to & from xml. The original code for this project was taken from [Arne Vandamme's weblog](http://www.jroller.com/page/CoBraLorD?entry=net_transparent_xml_serialization_xstream) which was a port of XStream for Java.


## Usage ##
```
string serialisedObject = new XStream().ToXml(originalObject);
object deserialisedObject = new XStream().FromXml(serialisedObject);
Assert.AreEqual(originalObject, deserialisedObject);
```