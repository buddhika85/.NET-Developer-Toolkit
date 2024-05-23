using C_Tests.SourceCode;
using static System.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        //DemoSealed();
        SingletonDemo();
    }

    private static void SingletonDemo()
    {
        WriteLine(Singleton.GetInstance());
        WriteLine(Singleton.GetInstance());
    }

    private static void DemoSealed()
    {
        IEnumerable<Parent> objs = new List<Parent> { new(), new ChildGenOne(), new ChildGenTwo() };
        foreach (var item in objs)
        {
            WriteLine(item);
        }
    }
}