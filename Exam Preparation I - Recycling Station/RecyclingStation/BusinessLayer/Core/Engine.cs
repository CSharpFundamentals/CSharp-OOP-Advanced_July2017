namespace RecyclingStation.BusinessLayer.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using BusinessLayer.Contracts.Core;
    using BusinessLayer.Contracts.IO;

    public class Engine : IEngine
    {
        private const string TerminatingCommand = "TimeToRecycle";

        private readonly MethodInfo[] RecyclingStationMethods;

        private IReader reader;
        private IWriter writer;

        private IRecyclingStation recyclingStation;

        public Engine(IReader reader, IWriter writer, IRecyclingStation recyclingStation)
        {
            this.reader = reader;
            this.writer = writer;
            this.recyclingStation = recyclingStation;

            this.RecyclingStationMethods = this.recyclingStation.GetType().GetMethods();
        }

        private string[] SplitStringByChar(string toSplit, params char[] toSplitBy)
        {
            return toSplit.Split(toSplitBy, StringSplitOptions.RemoveEmptyEntries);
        }

        public void Run()
        {
            string inputLine;
            while ((inputLine = this.reader.ReadLine()) != TerminatingCommand)
            {
                string[] commandArgs = this.SplitStringByChar(inputLine, ' ');
                
                string methodName = commandArgs[0];
                string[] methodNonParsedParams = null;
                if (commandArgs.Length == 2)
                {
                    methodNonParsedParams = this.SplitStringByChar(commandArgs[1], '|');
                }

                MethodInfo methodToInvoke = this.RecyclingStationMethods.FirstOrDefault(m => m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));

                ParameterInfo[] methodParams = methodToInvoke.GetParameters();

                object[] parsedParams = new object[methodParams.Length];
                for (int currentConvertion = 0; currentConvertion < methodParams.Length; currentConvertion++)
                {
                    Type currentParamType = methodParams[currentConvertion].ParameterType;

                    string toConvert = methodNonParsedParams[currentConvertion];

                    parsedParams[currentConvertion] = Convert.ChangeType(toConvert, currentParamType);
                }

                object result = methodToInvoke.Invoke(this.recyclingStation, parsedParams);

                this.writer.GatherOutput(result.ToString());
            }

            this.writer.WriteGatheredOutput();
        }
    }
}
