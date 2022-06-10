using Microsoft.EntityFrameworkCore;
using weba_folder.Models;

namespace weba_folder.Data {
    
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Item> Items {get; set;}

        public DbSet<Type> Types {get; set;}
    }
}