
namespace Bank_System_Prototype
{
    abstract class Worker
    {
        public abstract string GetClientInfo(Client currentClient);

        public abstract Client ChangePhoneNumber(Client currentClient, string phoneNumber);

    }
}
