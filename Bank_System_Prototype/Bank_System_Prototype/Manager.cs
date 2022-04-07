
namespace Bank_System_Prototype
{
    class Manager:Worker
    {
        public override void ChangeClientInfo(Client currentClient, params string[] clientData)
        {
            if(clientData[0] != string.Empty)
            {
                currentClient.PhoneNumber = clientData[0];
                LogChanges log = new LogChanges(DataType.PhoneData, WorkerType.Manager, TypeOfChanges.Change);
            }
            if (clientData[1] != string.Empty)
            {
                var nameParts = clientData[1].Split(' ');
                currentClient.FirstName = nameParts[0];
                currentClient.LastName = nameParts[1];
                LogChanges log = new LogChanges(DataType.NameData, WorkerType.Manager, TypeOfChanges.Change);
            }
            if (clientData[2] != string.Empty)
            {
                currentClient.PassportData = clientData[2];
                LogChanges log = new LogChanges(DataType.PassportData, WorkerType.Manager, TypeOfChanges.Change);
            }
        }

        public override string GetClientInfo(Client currentClient)
        {
            return $"{currentClient.FirstName} {currentClient.LastName} {currentClient.PassportData} {currentClient.PhoneNumber}";
        }
    }
}
