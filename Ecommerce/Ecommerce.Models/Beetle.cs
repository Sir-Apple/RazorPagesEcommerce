using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Beetle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
