namespace RecyclingStation.BusinessLayer.IO
{
    using System;
    using RecyclingStation.BusinessLayer.Contracts.IO;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
