using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

            // modelBuilder.ApplyConfiguration(new ProductConfig());
            // modelBuilder.ApplyConfiguration(new CategoryConfig());
            /*
            Eğer üstteki şekilde yaparsak her eklediğiiz nesnenin config kaydını buraya eklememiz gerekiyor.
            Fakat daha kolayı alltaki gibi yaparak bu olayın dinamik yapılmasını sağlayabiliriz.
            */

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                        
        }

    }
}