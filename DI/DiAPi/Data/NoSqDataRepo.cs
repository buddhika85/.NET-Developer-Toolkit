using DiAPi.DataServices;

namespace DiAPi.Data
{
    public class NoSqDataRepo :  IDataRepo
    {
        private readonly IDataService _dataService;

        // constructor dependency injection
        // whatever concrete type defined in the Program.cs for dependecy injection gets injected here
        public NoSqDataRepo(IDataService dataService)
        {
            _dataService = dataService;
        }

        public string ReturnData()
        {
            var message = $"No SQL Data No SQL DB - {_dataService.GetData("https://github.com/buddhika85")}";
            Utilities.WriteOnConsole(message, ConsoleColor.Green);
            return message;
        }
    }
}