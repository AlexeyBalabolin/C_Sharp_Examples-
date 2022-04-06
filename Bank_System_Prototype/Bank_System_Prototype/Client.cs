﻿
namespace Bank_System_Prototype
{
    public class Client: IChangeable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportData { get; set; }
        public string PhoneNumber { get; set; }

        LogChanges logChanges;

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

        public void ChangeData(DataType dataType, WorkerType workerType, TypeOfChanges typeOfChanges)
        {
            logChanges = new LogChanges(dataType, workerType, typeOfChanges);
        }
    }
}