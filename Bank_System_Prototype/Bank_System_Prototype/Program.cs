using System;
using System.Collections.Generic;

namespace Bank_System_Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "ClientsData/clients.xml";
            ClientsRepository<Client> repository1 = new ClientsRepository<Client>();
            repository1.AddClient(new Client("Alex", "Brown", "222222222222", "88005554444"));
            repository1.AddClient(new Client("Bob", "Smith", "2200222200002222", "8888888888"));

            foreach (var client in repository1)
                Console.WriteLine(client.GetInfo());

            Manager manager1 = new Manager();
            manager1.AddNewClient(repository1, new Client("Jack", "Sparrow", "2000111222333", "88005555555"));
            Console.WriteLine(manager1.GetClientInfo(repository1, 2));

            Consultant consultant1 = new Consultant();
            Console.WriteLine(consultant1.GetClientInfo(repository1, 2));

            consultant1.ChangeClientInfo(repository1, 1, "222111");
            Console.WriteLine(consultant1.GetClientInfo(repository1, 1));

            manager1.ChangeClientInfo(repository1, 0, "33", "Alex Brown", "0000000");

            List<Worker> workers = new List<Worker>() { consultant1, manager1 };
            foreach (var worker in workers)
                Console.WriteLine(worker.GetClientInfo(repository1, 0));

            Console.WriteLine();


            //сортировка репозитория по имени
            repository1.Clients.Sort();
            foreach (var client in repository1)
                Console.WriteLine(client.GetInfo());

            //перезапись данных
            //Serializer.Serialize(repository1, path);

        }
    }
}
