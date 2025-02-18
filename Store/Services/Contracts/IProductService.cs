using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trachChanges);
        Product? GetOneProduct(int id, bool trachChanges);

        void CreateProduct(Product product);
    }
    
}