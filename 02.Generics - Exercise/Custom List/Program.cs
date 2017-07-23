namespace Custom_List
{
    using System;

    public class Program
    {
        public static void Main()
        {
            CustomList<string> myCustomList = new CustomList<string>();
            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var tokens = inputLine.Split(' ');

                switch (tokens[0])
                {
                    case "Add":
                        myCustomList.Add(tokens[1]);
                        break;
                    case "Remove":
                       myCustomList.Remove(int.Parse(tokens[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(myCustomList.Contains(tokens[1]));
                        break;
                    case "Swap":
                        myCustomList.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));
                        break;
                    case "Greater":
                        Console.WriteLine(myCustomList.CountGreaterThan(tokens[1]));
                        break;
                    case "Min":
                        Console.WriteLine(myCustomList.Min());
                        break;
                    case "Max":
                        Console.WriteLine(myCustomList.Max());
                        break;
                    case "Sort":
                        myCustomList = Sorter.Sort(myCustomList);
                        break;
                    case "Print":
                        foreach (var element in myCustomList)
                        {
                            Console.WriteLine(element);
                        }
                        break;
                }
            }
        }
    }
}
