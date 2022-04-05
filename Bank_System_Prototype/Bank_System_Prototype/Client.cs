
namespace Bank_System_Prototype
{
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportData { get; set; }
        public string PhoneNumber { get; set; }

        public Client(string firstName, string lastName, string passportData, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PassportData = passportData;
            PhoneNumber = phoneNumber;
        }

        public Client()
        {

        }

        public string GetInfo()
        {
            return $"{FirstName} {LastName} {PassportData} {PhoneNumber}";
        }
    }
}
