namespace Tuples
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var inputTokens = Console.ReadLine().Split(' ');
            var names = $"{inputTokens[0]} {inputTokens[1]}";
            var address = inputTokens[2];
            var namesAdress = new Tuple<string, string>(names, address);
            Console.WriteLine(namesAdress);

            inputTokens = Console.ReadLine().Split(' ');
            var name = inputTokens[0];
            var liters = int.Parse(inputTokens[1]);
            var nameLiters = new Tuple<string, int>(name, liters);
            Console.WriteLine(nameLiters);

            inputTokens = Console.ReadLine().Split(' ');
            var intParam = int.Parse(inputTokens[0]);
            var doubleParam = double.Parse(inputTokens[1]);
            var intDouble = new Tuple<int, double>(intParam, doubleParam);
            Console.WriteLine(intDouble);
        }
    }
}
