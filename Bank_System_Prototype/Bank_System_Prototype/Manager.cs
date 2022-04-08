
namespace Bank_System_Prototype
{
    class Manager:Worker, IAddClient
    {
        public void AddNewClient(ClientsRepository<Client> currentRepository, Client currentClient)
        {
            currentRepository.AddClient(currentClient);
            LogChanges log = new LogChanges(DataType.NewClient, WorkerType.Manager, TypeOfChanges.Add);
        }

        public override void ChangeClientInfo(ClientsRepository<Client> currentRepository, int id, params string[] clientData)
        {
            if (clientData[0] != string.Empty)
            {
                currentRepository.Clients[id].PhoneNumber = clientData[0];
                LogChanges log = new LogChanges(DataType.PhoneData, WorkerType.Manager, TypeOfChanges.Change);
            }
            if (clientData[1] != string.Empty)
            {
                var nameParts = clientData[1].Split(' ');
                currentRepository.Clients[id].FirstName = nameParts[0];
                currentRepository.Clients[id].LastName = nameParts[1];
                LogChanges log = new LogChanges(DataType.NameData, WorkerType.Manager, TypeOfChanges.Change);
            }
            if (clientData[2] != string.Empty)
            {
                currentRepository.Clients[id].PassportData = clientData[2];
                LogChanges log = new LogChanges(DataType.PassportData, WorkerType.Manager, TypeOfChanges.Change);
            }
        }

        public override string GetClientInfo(ClientsRepository<Client> currentRepository, int id)
        {
            return $"{currentRepository.Clients[id].FirstName} " +
                $"{currentRepository.Clients[id].LastName} " +
                $"{currentRepository.Clients[id].PassportData} " +
                $"{currentRepository.Clients[id].PhoneNumber}";
        }
    }
}
