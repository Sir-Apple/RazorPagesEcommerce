using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Bugs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
