
using System;

namespace Bank_System_Prototype
{
    public class Client: IComparable
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

        public string GetInfo() => $"{FirstName} {LastName} {PassportData} {PhoneNumber}";


        /// <summary>
        /// реализация интерфейса IComparable для сортировки по параметру
        /// </summary>
        /// <param name="obj">клиент для сравнения с текущим</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            Client client = (Client)obj;
            return String.Compare(this.FirstName, client.FirstName);
        }
    }
}
