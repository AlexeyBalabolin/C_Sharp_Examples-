using System.Text;

namespace Bank_System_Prototype
{
    class Consultant
    {
        public string GetClientInfo(Client currentClient)
        {
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < currentClient.PassportData.Length; i++)
                sBuilder.Append("*");
            return $"{currentClient.FirstName} {currentClient.LastName} {sBuilder} {currentClient.PhoneNumber}";
        }

        public Client ChangePhoneNumber(Client currentClient, string phoneNumber)
        {
            if (phoneNumber != string.Empty)
                currentClient.PhoneNumber = phoneNumber;
            return currentClient;
        }
    }
}
