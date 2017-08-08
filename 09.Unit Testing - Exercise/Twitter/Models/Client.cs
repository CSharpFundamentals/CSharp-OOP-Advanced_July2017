namespace Models
{
    using Interfaces;

    public class MicrowaveOven : IClient
    {
        private IWriter writer;

        public MicrowaveOven(IWriter writer)
        {
            this.writer = writer;
        }

        public void RetrieveMessage(IMessage message)
        {
            writer.WriteLine(message.Content);
            this.RedirectToServer(message);
        }

        private void RedirectToServer(IMessage message)
        {
            writer.WriteLine("Redirected to server!");
        }
    }
}
