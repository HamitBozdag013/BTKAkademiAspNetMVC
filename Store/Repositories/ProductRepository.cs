using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateProduct(Product product) =>Create(product);
        public void DeleteProduct(Product product) =>Remove(product);
        public void UpdateProduct(Product product) =>Update(product);

        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return FindByCondition(p=>p.ProductId.Equals(id),trackChanges);
        }
    }
}