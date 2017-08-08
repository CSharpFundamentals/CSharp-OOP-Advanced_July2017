using System;
using Interfaces;
using Models;

namespace Twitter
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IMessage tweet = new Tweet("test msg");
            IWriter console = new ConsoleWriter();
            IClient microwave = new MicrowaveOven(console);
            microwave.RetrieveMessage(tweet);
            
        }
    }
}
