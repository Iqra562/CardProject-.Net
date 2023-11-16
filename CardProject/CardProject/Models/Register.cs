using System.ComponentModel.DataAnnotations;

namespace CardProject.Models
{
    public class Register
    {
        [Key]
        public int RegisterId { get; set; }
        [Required]
        public string Name { get; set; }

        public string email { get; set; }
        public string password { get; set; }


    }
}
