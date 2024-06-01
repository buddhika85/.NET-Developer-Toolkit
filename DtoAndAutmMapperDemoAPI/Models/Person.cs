using System.ComponentModel.DataAnnotations;

namespace DtoAndAutmMapperDemoAPI.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; } = null!;
        [Required]
        public string Telephone { get; set;} = null!;
        [Required]
        public string DOB { get; set; } = null!;
    }
}