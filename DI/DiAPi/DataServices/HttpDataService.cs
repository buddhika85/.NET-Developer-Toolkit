namespace DiAPi.DataServices
{
    public class HttpDataService : IDataService
    {
        public string GetData(string url)
        {
            var message = $"Getting data from - {url}";
            Utilities.WriteOnConsole(message, ConsoleColor.Yellow);
            return message;
        }
    }
}