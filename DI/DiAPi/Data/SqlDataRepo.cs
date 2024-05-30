

namespace DiAPi.Data
{
    public class SqlDataRepo
    {
        public string ReturnData()
        {
            var message = "SQL Data from DB";
            Utilities.WriteOnConsole(message);
            return message;
        }
    }
}