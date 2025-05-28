
namespace C_Tests.SourceCode
{
    public class Box<T>
    {
        public T? Value { get; set; }

        public Box(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value?.ToString() ?? string.Empty;
        }
    }
}
