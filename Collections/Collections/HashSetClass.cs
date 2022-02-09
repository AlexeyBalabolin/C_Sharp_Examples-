using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8
{
    class HashSetClass
    {
        public HashSet<int> FillHashSet(HashSet<int> currentHashSet)
        {
            while(true)
            {
                Console.WriteLine("Введите число, которое нужно добавить");
                int number = int.Parse(Console.ReadLine());
                if (currentHashSet.Add(number))
                {
                    Console.WriteLine("Число добавлено");
                }
                else
                {
                    Console.WriteLine("Число уже есть в коллекции");
                    break;
                }
            }
            return currentHashSet;
        }

        public void Print(HashSet<int> currentHashSet)
        {
            foreach (var v in currentHashSet)
                Console.Write($"{v} ");
        }
    }
}
