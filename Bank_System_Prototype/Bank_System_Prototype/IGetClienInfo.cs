
namespace Bank_System_Prototype
{
    interface IGetClienInfo
    {
        string GetClientInfo(ClientsRepository<Client> currentRepository, int id);
    }
}
