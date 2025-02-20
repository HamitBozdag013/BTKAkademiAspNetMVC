using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class RepositoryContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
        {

        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                        
        }

    }
}