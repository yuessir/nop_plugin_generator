using System.Xml.Serialization;

namespace NopPluginGenerator.Utility
{
    public class XmlSerializationHelper
    {
        public static void Save<T>(string filename, T obj) where T: class
        {
            using (var writer = new System.IO.StreamWriter(filename))
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, obj);
                writer.Flush();
            }
        }

        public static T Load<T>(string filename) where T:class
        {
            using (var stream = System.IO.File.OpenRead(filename))
            {
                var serializer = new XmlSerializer(typeof(T));
                return serializer.Deserialize(stream) as T;
            }
        }
    }
}