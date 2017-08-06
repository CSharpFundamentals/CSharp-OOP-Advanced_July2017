namespace _03BarracksFactory.Core.Commands
{
    using System;
    using Contracts;

    public class FightCommand : Command
    {
        public FightCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return string.Empty;
        }
    }
}
