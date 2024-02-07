using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

    }
}
