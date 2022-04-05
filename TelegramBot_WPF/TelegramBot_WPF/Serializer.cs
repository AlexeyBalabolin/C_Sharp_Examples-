using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TelegramBot_WPF
{
    static class Serializer
    {
        static string path = "Messages/messages.xml";
        public static void Serialize(List<MessageLog> clients)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<MessageLog>));
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
            serializer.Serialize(stream, clients);
            stream.Close();
        }

        public static List<MessageLog> Deserialize()
        {
            List<MessageLog> deserializedMessageLog = new List<MessageLog>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<MessageLog>));
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            deserializedMessageLog = serializer.Deserialize(stream) as List<MessageLog>;
            stream.Close();
            return deserializedMessageLog;
        }
    }
}
