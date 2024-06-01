using System.ComponentModel.DataAnnotations;

namespace DtoAndAutmMapperDemoAPI.Dtos
{
    public class PersonUpdateDto
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string Telephone { get; set;} = null!;
        [Required]
        public string DOB { get; set; } = null!;
    }
}