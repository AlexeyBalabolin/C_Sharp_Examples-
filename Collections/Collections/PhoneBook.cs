using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8
{
    class PhoneBook
    {
        public Dictionary<string, string> FillPhoneBook(Dictionary<string, string> currentDictionary)
        {
            while (true)
            {
                Console.WriteLine("Введите номер телефона");
                string phoneNumber = Console.ReadLine();
                if (phoneNumber == string.Empty)
                    break;
                Console.WriteLine("Введите имя");
                string contactName = Console.ReadLine();
                AddContact(currentDictionary, phoneNumber, contactName);
            }
            return currentDictionary;
        }

        public void AddContact(Dictionary<string, string> dictionary,string phoneNumber, string name)
        {
            try
            {
                dictionary.Add(phoneNumber, name);
            }
            catch(Exception e)
            {
                Console.WriteLine("В словаре уже есть такая запись");
            }
        }

        public string GetContact(Dictionary<string, string> currentDictionary, string phoneNumber)
        {
            string value = string.Empty;
            if (currentDictionary.TryGetValue(phoneNumber, out value))
                return value;
            else
                return "Нет контакта с указанным номером";
        }
    }
}
