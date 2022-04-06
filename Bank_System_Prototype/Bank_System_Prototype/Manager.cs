
namespace Bank_System_Prototype
{
    class Manager:Consultant
    {
        public Client ChangeName(Client currentClient, string firstName, string lastName)
        {
            if (firstName != string.Empty && lastName != string.Empty)
            {
                currentClient.FirstName = firstName;
                currentClient.LastName = lastName;
                currentClient.ChangeData(DataType.NameData, WorkerType.Manager, TypeOfChanges.Change);
            }
            return currentClient;
        }

        public Client ChangePassportData(Client currentClient, string passportData)
        {
            if (passportData != string.Empty)
            {
                currentClient.PassportData = passportData;
                currentClient.ChangeData(DataType.PassportData, WorkerType.Manager, TypeOfChanges.Change);
            }
            return currentClient;
        }
    }
}
