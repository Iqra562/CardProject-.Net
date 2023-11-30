using System.ComponentModel.DataAnnotations;

namespace CardProject.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public float Price { get; set; }
        [Required]

        public int Quantity { get; set; }
        [Required]

        public string Image { get; set; }
        public  int CategoryId { get; set; }
        public Category Category { get; set; }
        public int BrandId { get; set; }    
        public Brand Brand { get; set; }


    }
}
