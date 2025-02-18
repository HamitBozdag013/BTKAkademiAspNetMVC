using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;

        public ProductManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateProduct(Product product)
        {
            _manager.Product.Create(product);
            _manager.Save();
        }

        public IEnumerable<Product> GetAllProducts(bool trachChanges)
        {
            return _manager.Product.GetAllProducts(trachChanges);
        }

        public Product? GetOneProduct(int id, bool trachChanges)
        {
            var value = _manager.Product.GetOneProduct(id, trachChanges);
            if(value is null) 
                throw new Exception("Product not found!");
            return value;
        }
    }
}