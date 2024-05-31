using static System.Console;
namespace DiAPi
{
    public static class Utilities
    {
        public static void WriteOnConsole(string message, ConsoleColor color =  ConsoleColor.Red)// default red
        {
            ForegroundColor = color;
            WriteLine($"-->{message} ...");
            ResetColor();
        }
    }
}