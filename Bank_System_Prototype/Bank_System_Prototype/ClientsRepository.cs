using System;
using System.Collections;
using System.Collections.Generic;

namespace Bank_System_Prototype
{
    public class ClientsRepository<T>:IEnumerable<Client>
    {
        private List<Client> clients = new List<Client>();

        public List<Client> Clients { get { return clients; } }

        public void AddClient(Client currentClient)
        {
            clients.Add(currentClient);
        }

        public void RemoveClientByName(string currentName)
        {
            for (int i = 0; i < clients.Count; i++)
                if (clients[i].FirstName == currentName)
                    clients.RemoveAt(i);
        }

        public IEnumerator<Client> GetEnumerator() => clients.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public ClientsRepository()
        {

        }

        public void Add(T value)
        {

        }

    }
}
