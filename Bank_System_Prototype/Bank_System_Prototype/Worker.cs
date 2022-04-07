
namespace Bank_System_Prototype
{
    abstract class Worker:IGetClienInfo, IChangeInfo
    {
        public abstract string GetClientInfo(Client currentClient);

        public abstract void ChangeClientInfo(Client currentClient, params string[] clientData);
    }
}
