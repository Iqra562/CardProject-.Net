namespace CardProject.Models
{
    public class Product
    {
        public int ProductId { get; set; } 
        public string Name { get; set; } 
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public  int CategoryId { get; set; }
        public Category Category { get; set; }
        public int BrandId { get; set; }    
        public Brand Brand { get; set; }


    }
}
