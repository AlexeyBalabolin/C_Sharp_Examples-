namespace Bank_System_Prototype
{
    interface IChangeInfo
    {
        void ChangeClientInfo(ClientsRepository<Client> currentRepository, int id , params string[] clientData);
    }
}
