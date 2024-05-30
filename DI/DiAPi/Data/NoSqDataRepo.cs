using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiAPi.Data
{
    public class NoSqDataRepo :  IDataRepo
    {
        public string ReturnData()
        {
            var message = "No SQL Data No SQL DB";
            Utilities.WriteOnConsole(message, ConsoleColor.Green);
            return message;
        }
    }
}