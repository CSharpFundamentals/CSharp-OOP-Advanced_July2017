namespace _03BarracksFactory.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using Attributes;
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
                data
            };

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            IExecutable currentCommand =  (IExecutable)Activator.CreateInstance(commandType, commandParams);

            currentCommand = this.InjectDependencies(currentCommand);

            return currentCommand;
        }

        private IExecutable InjectDependencies(IExecutable currentCommand)
        {
            FieldInfo[] commandFileds = currentCommand.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttributes<InjectAttribute>() != null)
                .ToArray();

            FieldInfo[] interpeterFileds = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo commandField in commandFileds)
            {
                FieldInfo interpreterField = interpeterFileds
                    .First(f => f.FieldType == commandField.FieldType);
                object valueToInject = interpreterField.GetValue(this);

                commandField.SetValue(currentCommand, valueToInject);
            }

            return currentCommand;
        }
    }
}
