using System.IO;
using System.Xml.Serialization;

namespace Bank_System_Prototype
{
    static class Serializer
    {
        public static void Serialize(ClientsRepository<Client> repository, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ClientsRepository<Client>));
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
            serializer.Serialize(stream, repository);
            stream.Close();
        }

        public static ClientsRepository<Client> Deserialize(string path)
        {
            ClientsRepository<Client> deserializedContact = new ClientsRepository<Client>();
            XmlSerializer serializer = new XmlSerializer(typeof(ClientsRepository<Client>));
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            deserializedContact = serializer.Deserialize(stream) as ClientsRepository<Client>;
            stream.Close();
            return deserializedContact;
        }
    }
}
