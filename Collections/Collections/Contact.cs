using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8
{
    public class Contact
    {
        public string FullName { get; set; }
        public string Street { get; set; }
        public uint HouseNumber { get; set; }
        public uint AppartmentNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string FlatPhoneNumber { get; set; }

        public Contact(string fullName, string street, uint houseNumber, uint appartmentNumber, string mobilePhoneNumber, string flatPhoneNumber)
        {
            FullName = fullName;
            Street = street;
            HouseNumber = houseNumber;
            AppartmentNumber = appartmentNumber;
            MobilePhoneNumber = mobilePhoneNumber;
            FlatPhoneNumber = flatPhoneNumber;
        }

        //конструктор без параметров, без него не работает xml сериализация
        public Contact()
        {

        }

        public void Print()
        {
            Console.WriteLine($"{FullName} {Street} {HouseNumber} {AppartmentNumber} {MobilePhoneNumber} {FlatPhoneNumber}");
    }
    }
}
