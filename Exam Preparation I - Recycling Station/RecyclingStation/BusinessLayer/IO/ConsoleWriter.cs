namespace RecyclingStation.BusinessLayer.IO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RecyclingStation.BusinessLayer.Contracts.IO;

    class ConsoleWriter : IWriter
    {
        private StringBuilder outputGatherer;

        public ConsoleWriter()
            : this(new StringBuilder())
        {
        }

        public ConsoleWriter(StringBuilder outputGatherer)
        {
            this.OutputGatherer = outputGatherer;
        }

        public StringBuilder OutputGatherer
        {
            get
            {
                return this.outputGatherer;
            }

            private set
            {
                this.outputGatherer = value;
            }
        }

        public void GatherOutput(string outputToGather)
        {
            this.OutputGatherer.AppendLine(outputToGather);
        }

        public void WriteGatheredOutput()
        {
            Console.Write(this.OutputGatherer);
        }
    }
}
