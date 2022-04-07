namespace Bank_System_Prototype
{
    interface IChangeInfo
    {
        void ChangeClientInfo(Client currentClient, params string[] clientData);
    }
}
