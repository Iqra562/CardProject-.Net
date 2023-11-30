using System.ComponentModel.DataAnnotations;

namespace CardProject.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        public string BrandName { get; set; }    
        public ICollection<Product> products { get; set; }
    }
}
