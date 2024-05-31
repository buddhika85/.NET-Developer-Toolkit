using System.Text.Json.Serialization;

namespace JsonSerializationDeerialization.Models
{
    public class Phone
    {
        public PhoneType Type { get; set; }

        [JsonPropertyName("homeOrMobile")]
        public string PhoneTypeStr => Type.GetPhoneDisplayableName();
        public string? PhoneNumber { get; set; }
    }

    public enum PhoneType
    {
        Home = 1,
        Mobile = 2
    }
}

