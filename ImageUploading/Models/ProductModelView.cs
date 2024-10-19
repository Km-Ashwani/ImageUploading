using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ImageUploading.Models
{
    public class ProductModelView
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public IFormFile picture { get; set; }
    }
}
