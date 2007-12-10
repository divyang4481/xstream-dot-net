using System.IO;

namespace Xstream.Core
{
    public class FileXStream
    {
        private readonly string fileName;

        public FileXStream(string fileName) {
            this.fileName = fileName;
        }

        public virtual void ToFile(object @object)
        {
            string xml = new XStream().ToXml(@object);
            File.WriteAllText(fileName, xml);
        }
    }
}