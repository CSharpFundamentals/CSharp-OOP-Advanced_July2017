namespace Strategy_Pattern
{
    using System;
    using System.Collections.Generic;
    using Comparators;

    public class Program
    {
        public static void Main()
        {
            SortedSet<Person> peopleSortedByName = new SortedSet<Person>(new NameComparator());
            SortedSet<Person> peopleSortedByAge = new SortedSet<Person>(new AgeComparator());

            int peopleCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleCount; i++)
            {
                var personTokens = Console.ReadLine().Split();
                Person person = new Person(personTokens[0], int.Parse(personTokens[1]));

                peopleSortedByName.Add(person);
                peopleSortedByAge.Add(person);
            }

            foreach (var person in peopleSortedByName)
            {
                Console.WriteLine(person);
            }

            foreach (var person in peopleSortedByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
