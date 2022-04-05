using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Bank_System_Prototype
{
    static class Serializer
    {
        public static void Serialize(List<Client> clients, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Client>));
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
            serializer.Serialize(stream, clients);
            stream.Close();
        }

        public static List<Client> Deserialize(string path)
        {
            List<Client> deserializedContact = new List<Client>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Client>));
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            deserializedContact = serializer.Deserialize(stream) as List<Client>;
            stream.Close();
            return deserializedContact;
        }
    }
}
