namespace C_Tests.SourceCode
{
    public class Parent
    {
        public virtual string  M(){
            return "Parent";
        }

        protected string GetClassNameStr()
        {
            return GetType().Name;
        }

        public override string ToString()
        {
            return $"{GetClassNameStr()} - {M()}";
        }
    }

    public class ChildGenOne : Parent
    {
         sealed override public string M(){
            return "Child GenOne - made it sealed, so end of overriding";
        }
    }

    public class ChildGenTwo : ChildGenOne
    {
        // override public string M(){
        //     Console.WriteLine("Child GenTwo");
        // }
    }
}