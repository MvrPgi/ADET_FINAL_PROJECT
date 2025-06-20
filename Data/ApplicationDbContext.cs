using ADET_FINAL_PROJECT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ADET_FINAL_PROJECT.Data
{
    public class ApplicationDbContext : DbContext 
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; } 
        public DbSet<User> Users { get; set; }
    }
}
