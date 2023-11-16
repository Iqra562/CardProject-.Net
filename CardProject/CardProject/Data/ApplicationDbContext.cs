using CardProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetConnection.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Register> Registers { get; set; }
    }
}