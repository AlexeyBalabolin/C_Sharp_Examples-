using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Homework8
{
    class Program
    {
        
        static void Main(string[] args)
        {
            #region Задание 1 работа с List
            //List<int> listOfNumbers = new List<int>();
            //FillList(listOfNumbers);
            //PrintList(listOfNumbers);
            //Console.WriteLine();
            //Console.WriteLine();
            //RemoveValues(listOfNumbers);
            //PrintList(listOfNumbers);
            #endregion

            #region задание 2 работа с Dictionary
            //PhoneBook phoneBook = new PhoneBook();
            //Dictionary<string, string> phoneDictionary = new Dictionary<string, string>();
            //phoneDictionary = phoneBook.FillPhoneBook(phoneDictionary);
            //Console.WriteLine("Введите номер для поиска контакта");
            //string findPhoneNumber = Console.ReadLine();
            //Console.WriteLine($"Найденный контакт: {phoneBook.GetContact(phoneDictionary, findPhoneNumber)}");
            #endregion

            #region задание 3 работа с HashSet
            //HashSetClass myHashSet = new HashSetClass();
            //HashSet<int> hashSet = new HashSet<int>();
            //hashSet=myHashSet.FillHashSet(hashSet);
            //myHashSet.Print(hashSet);
            #endregion

            #region задание 4 сериализация
            //string path = "complexityContact.xml";

            //Console.WriteLine("Введите имя");
            //string name = Console.ReadLine();
            //Console.WriteLine("Введите улицу");
            //string street = Console.ReadLine();
            //Console.WriteLine("Введите номер дома");
            //uint houseNumber = uint.Parse(Console.ReadLine());
            //Console.WriteLine("Введите номер квартиры");
            //uint appartmentNumber = uint.Parse(Console.ReadLine());
            //Console.WriteLine("Введите номер мобильного телефона");
            //string mobilePhoneNumber = Console.ReadLine();
            //Console.WriteLine("Введите номер домашнего телефона");
            //string flatPhoneNumber = Console.ReadLine();

            //Contact contact = new Contact(name, street, houseNumber, appartmentNumber, mobilePhoneNumber, flatPhoneNumber);
            //contact.Print();
            //SerializeComplexityContact(contact, path);
            #endregion
        }

        #region Методы 1 задания
        //заполнение коллекции
        public static void FillList(List<int> currentList)
        {
            Random rnd = new Random();
            for(int i=0;i<100;i++)
            {
                currentList.Add(rnd.Next(0, 100));
            }
        }

        //вывод коллекции на экран
        public static void PrintList(List<int> currentList)
        {
            for(int i=0;i<currentList.Count;i++)
            {
                Console.Write($"{currentList[i]} ");
            }
        }

        //удаление из коллекции значений меньше maxValue и больше minValue
        public static void RemoveValues(List<int> currentList)
        {
            currentList.RemoveAll(inRange);
        }

        //Predicate
        private static bool inRange(int i)
        {
            int minValue = 25;
            int maxValue = 50;
            return i > minValue && i < maxValue;
        }
        #endregion
        #region Методы 4 задания
        static void SerializeContact(Contact currentContact, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Contact));
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
            serializer.Serialize(stream, currentContact);
            stream.Close();
        }

        static Contact DeserializeContact(string path)
        {
            Contact deserializedContact = new Contact();
            XmlSerializer serializer = new XmlSerializer(typeof(Contact));
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            deserializedContact = serializer.Deserialize(stream) as Contact;
            stream.Close();
            return deserializedContact;
        }

        static void SerializeComplexityContact(Contact contact ,string path)
        {
            XElement person = new XElement("Person");
            XElement adress = new XElement("Adress");
            XElement street = new XElement("Street");
            XElement houseNumber = new XElement("HouseNumber");
            XElement flatNumber = new XElement("FlatNumber");
            XElement phones = new XElement("Phones");
            XElement mobilePhone = new XElement("MobilePhone");
            XElement flatPhone = new XElement("FlatPhone");

            XAttribute xAttributeName = new XAttribute("name", contact.FullName);

            street.Add(contact.Street);
            houseNumber.Add(contact.HouseNumber);
            flatNumber.Add(contact.AppartmentNumber);
            adress.Add(street);
            adress.Add(houseNumber);
            adress.Add(flatNumber);

            mobilePhone.Add(contact.MobilePhoneNumber);
            flatPhone.Add(contact.FlatPhoneNumber);
            phones.Add(mobilePhone);
            phones.Add(flatPhone);

            person.Add(adress, phones ,xAttributeName);
            person.Save(path);

            Console.WriteLine("Контакт сохранен");
        }

        #endregion
    }
}
