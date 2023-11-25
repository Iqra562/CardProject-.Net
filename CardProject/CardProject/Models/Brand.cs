namespace CardProject.Models
{
    public class Brand
    {
        public int BrandId { get; set; } 
        public string BrandName { get; set; }    
        public ICollection<Product> products { get; set; }
    }
}
