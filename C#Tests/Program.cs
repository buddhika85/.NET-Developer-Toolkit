using C_Tests.SealedTest;
using static System.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        DemoSealed();

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