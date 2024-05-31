using JsonSerializationDeerialization.Models;

namespace JsonSerializationDeerialization
{
    public static class EnumExtensions
    {
        public static string GetPhoneDisplayableName(this PhoneType type)
        {
            if (type == PhoneType.Home)
                return "Home";
            return "Mobile";
        }
    }
}