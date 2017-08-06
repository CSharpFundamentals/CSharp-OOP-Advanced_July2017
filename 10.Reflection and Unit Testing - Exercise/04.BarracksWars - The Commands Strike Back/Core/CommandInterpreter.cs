namespace _03BarracksFactory.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSuffix = "Command";

        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string commandCompleteName = 
                CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandSuffix;
            
            Type commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandCompleteName);

            object[] commandParams =
            {
                data,
                this.repository,
                this.unitFactory
            };

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            return (IExecutable)Activator.CreateInstance(commandType, commandParams);
        }
    }
}
