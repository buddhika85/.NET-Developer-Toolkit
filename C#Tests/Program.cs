using C_Tests.SourceCode;
using static System.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        //DemoSealed();
        //SingletonDemo();

        // generics
        //var nums = new int []  { 1, 2, 3 };
        //var chars = new List<char> { 'a', 'b' };
        //var strs = new List<string> { "quick", "brown", "fox"};
        //WriteLine(Concatenate(nums, ","));
        //WriteLine(Concatenate(chars, " | "));
        //WriteLine(Concatenate(strs, " "));

        //var box1 = new Box<int>(1);
        //var box2 = new Box<double>(1.99);
        //var box3 = new Box<string>("string");

        BaseClass baseObj = new BaseClass();
        baseObj.Show(); // Calls BaseClass.Show()

        DerivedClass derivedObj = new DerivedClass();
        derivedObj.Show(); // Calls DerivedClass.Show()

        BaseClass refObj = new DerivedClass();
        refObj.Show(); // Calls BaseClass.Show() (method hiding prevents overriding
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

    static string Concatenate<T>(IEnumerable<T> list, string seprator)
    {
       return string.Join(seprator, list);
    }
}