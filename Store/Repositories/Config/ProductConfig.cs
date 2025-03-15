using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p=>p.ProductId);
            builder.Property(p=>p.ProductName).IsRequired();
            builder.Property(p=>p.Price).IsRequired();

            builder.HasData(
                new Product() { ProductId = 1, CategoryId=2, ProductName = "Computer", Price = 17000, ImageUrl="/images/1.jpg" },
                new Product() { ProductId = 2, CategoryId=2, ProductName = "Keyboard", Price = 1000, ImageUrl="/images/2.jpg" },
                new Product() { ProductId = 3, CategoryId=2, ProductName = "Mouse", Price = 500, ImageUrl="/images/3.jpg" },
                new Product() { ProductId = 4, CategoryId=2, ProductName = "Monitör", Price = 7000, ImageUrl="/images/4.jpg" },
                new Product() { ProductId = 5, CategoryId=1, ProductName = "History", Price = 1500, ImageUrl="/images/5.jpg" },
                new Product() { ProductId = 6, CategoryId=2, ProductName = "SSD", Price = 800, ImageUrl="/images/6.jpg" }
            );

        }
    }
}