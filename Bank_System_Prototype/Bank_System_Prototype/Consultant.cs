using System.Text;

namespace Bank_System_Prototype
{
    class Consultant : Worker
    {
        public override void ChangeClientInfo(Client currentClient, params string[] clientData)
        {
            if(clientData[0] !=string.Empty)
            {
                currentClient.PhoneNumber = clientData[0];
                LogChanges log = new LogChanges(DataType.PhoneData, WorkerType.Consultant, TypeOfChanges.Change);
            }
        }

        public override string GetClientInfo(Client currentClient)
        {
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < currentClient.PassportData.Length; i++)
                sBuilder.Append("*");
            return $"{currentClient.FirstName} {currentClient.LastName} {sBuilder} {currentClient.PhoneNumber}";
        }
    }
}
