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

            clients[0] = consultant1.ChangePhoneNumber(clients[0], "2222222");
            Console.WriteLine(consultant1.GetClientInfo(clients[0]));

            Manager manager1 = new Manager();
            clients[1]=manager1.ChangePassportData(clients[1], "222256785456");
            Console.WriteLine(manager1.GetClientInfo(clients[1]));
            Console.WriteLine(clients[1].GetInfo());

            /*
            //перезапись данных
            Serializer.Serialize(clients, path);
            */

        }
    }
}
