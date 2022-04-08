
namespace Bank_System_Prototype
{
    abstract class Worker:IGetClienInfo, IChangeInfo
    {
        public abstract string GetClientInfo(ClientsRepository<Client> currentRepository, int id);

        public abstract void ChangeClientInfo(ClientsRepository<Client> currentRepository, int id , params string[] clientData);
    }
}
