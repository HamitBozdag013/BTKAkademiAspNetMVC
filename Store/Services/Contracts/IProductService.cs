using Entities.Models;
using Entities.DTOs;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trachChanges);
        Product? GetOneProduct(int id, bool trachChanges);

        void CreateProduct(ProductDtoForInsertion productDto);
        void UpdateProduct(ProductDtoForUpdate productDto);
        void DeleteProduct(int id);
        ProductDtoForUpdate GetOneProductForUpdate(int id,bool trachChanges);
    }
    
}