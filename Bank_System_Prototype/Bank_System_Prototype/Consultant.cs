using System.Text;

namespace Bank_System_Prototype
{
    class Consultant : Worker
    {

        public override void ChangeClientInfo(ClientsRepository<Client> currentRepository, int id, params string[] clientData)
        {
            if (clientData[0] != string.Empty)
            {
                currentRepository.Clients[id].PhoneNumber = clientData[0];
                LogChanges log = new LogChanges(DataType.PhoneData, WorkerType.Consultant, TypeOfChanges.Change);
            }
        }

        public override string GetClientInfo(ClientsRepository<Client> currentRepository , int id)
        {
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < currentRepository.Clients[id].PassportData.Length; i++)
                sBuilder.Append("*");
            return $"{currentRepository.Clients[id].FirstName} {currentRepository.Clients[id].LastName} " +
                $"{sBuilder} {currentRepository.Clients[id].PhoneNumber}";
        }
    }
}
