using System.ComponentModel.DataAnnotations;

namespace CardProject.Models
{
    public class Category
    {
        [Key]
        public  int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public ICollection<Product> products { get; set; }
    }
}
