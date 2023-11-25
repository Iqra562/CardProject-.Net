namespace CardProject.Models
{
    public class Category
    {
        public  int CategoryId { get; set; }    
        public string CategoryName { get; set; }
        public ICollection<Category> categories { get; set; }
    }
}
