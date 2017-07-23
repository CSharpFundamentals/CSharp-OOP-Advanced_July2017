namespace Collection_Hierarchy
{
    using System;
    using System.Text;
    using Interfaces;

    public class Program
    {
        public static void Main()
        {
            IAddCollection<string> addColletion = new AddCollection<string>();
            IAddRemoveCollection<string> addRemCollection = new AddRemoveCollection<string>();
            IMyList<string> myList = new MyList<string>();

            var itemsToAdd = Console.ReadLine().Split(' ');
            var removeOperationsCount = int.Parse(Console.ReadLine());

            var addCollAddIndexes = new StringBuilder();
            var addRemCollAddIndexes = new StringBuilder();
            var myListCollAddIndexes = new StringBuilder();

            foreach (var item in itemsToAdd)
            {
                addCollAddIndexes.Append($"{addColletion.Add(item)} ");
                addRemCollAddIndexes.Append($"{addRemCollection.Add(item)} ");
               myListCollAddIndexes.Append($"{myList.Add(item)} ");
            }

            var addRemCollRemoveElements = new StringBuilder();
            var myListRemoveElements = new StringBuilder();

            for (int i = 0; i < removeOperationsCount; i++)
            {
                addRemCollRemoveElements.Append($"{addRemCollection.Remove()} ");
                myListRemoveElements.Append($"{myList.Remove()} ");
            }
            
            Console.WriteLine(addCollAddIndexes.ToString().Trim());
            Console.WriteLine(addRemCollAddIndexes.ToString().Trim());
            Console.WriteLine(myListCollAddIndexes.ToString().Trim());

            Console.WriteLine(addRemCollRemoveElements.ToString().Trim());
            Console.WriteLine(myListRemoveElements.ToString().Trim());
        }
    }
}
