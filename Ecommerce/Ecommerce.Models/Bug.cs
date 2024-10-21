using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Bug
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
