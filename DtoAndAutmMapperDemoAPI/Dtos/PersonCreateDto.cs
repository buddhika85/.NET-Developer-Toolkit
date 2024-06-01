using System.ComponentModel.DataAnnotations;

namespace DtoAndAutmMapperDemoAPI.Dtos
{
    public class PersonCreateDto
    {       
        // [Required]
        // public string FullName { get; set; } = null!;

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