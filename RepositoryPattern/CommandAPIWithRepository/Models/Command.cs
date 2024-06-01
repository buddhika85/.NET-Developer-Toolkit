using System.ComponentModel.DataAnnotations;

namespace CommandAPINoRepository.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CommandId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string HowTo { get; set; } = null!;

        [Required]
        public string Platform { get; set; } = null!;    

        [Required] 
        public string CommandLine { get; set; } = null!;
    }
}