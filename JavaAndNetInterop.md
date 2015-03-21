# Java and .NET interop with XStream #

You can use the Java and .NET XStream projects to inter-operate between Java and .NET. This is a dangerous en devour, but it might be useful in some cases. This page describes some reasons why you might not want to do it, and then runs you through some code to the interop to work properly.

## Should you use XStream for Java and .NET interop? ##

I used XStream.NET to interoperate with java. Using the two libraries I could serialize a java object and then deserialize it with .net and then pass the XML over a web service.

On an implementation level, I had to modify the XStream.net library to support collections. That wasn't too hard. Then I needed to make sure that I didn't capitalize certain variables. Finally, I needed to use Aliases to deserialize properly.

The real problem that killed the idea was that I was coupling the Java and .NET implementations to XStream, which does not produce an XSD. So any other code not using XStream would need to do some work to interoperate.

So, if you plan on any external code accessing your serialized classes. Don't make them use XStream and just use and XSD and XMLBeans or something. If you are sure these serialized classes are internal, then go ahead and do it. You will save yourself from having to make an XSD.

## How to do it ##
