using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DtoAndAutmMapperDemoAPI.Dtos
{
    public class PersonDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; } = null!;
        [Required]
        public string Telephone { get; set;} = null!;

        
        // [Required]
        // public string DOB { get; set; } = null!;
    }
}