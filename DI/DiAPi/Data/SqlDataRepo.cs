

namespace DiAPi.Data
{
    public class SqlDataRepo : IDataRepo
    {
        public string ReturnData()
        {
            var message = "SQL Data from DB";
            Utilities.WriteOnConsole(message);
            return message;
        }
    }
}