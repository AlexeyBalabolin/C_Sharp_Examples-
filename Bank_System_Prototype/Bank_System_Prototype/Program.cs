using System;
using System.Collections.Generic;

namespace Bank_System_Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "ClientsData/clients.xml";
            List<Client> clients = new List<Client>();

            clients = Serializer.Deserialize(path);
            foreach (var client in clients)
                Console.WriteLine(client.GetInfo());
            Console.WriteLine();

            Consultant consultant1 = new Consultant();
            Console.WriteLine(consultant1.GetClientInfo(clients[1]));
            consultant1.ChangeClientInfo(clients[0], "2222222");
            Console.WriteLine(consultant1.GetClientInfo(clients[0]));
            Console.WriteLine();

            Manager manager1 = new Manager();
            Console.WriteLine(manager1.GetClientInfo(clients[1]));
            manager1.ChangeClientInfo(clients[1], "88007774455", "Peter Parker", "1234 1234 4564 4643");
            Console.WriteLine(manager1.GetClientInfo(clients[1]));

            /*
            //перезапись данных
            Serializer.Serialize(clients, path);
            */

        }
    }
}
