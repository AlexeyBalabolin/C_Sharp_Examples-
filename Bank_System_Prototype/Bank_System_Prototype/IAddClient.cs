
namespace Bank_System_Prototype
{
    interface IAddClient
    {
        void AddNewClient(ClientsRepository<Client> currentRepository, Client currentClient);
    }
}
