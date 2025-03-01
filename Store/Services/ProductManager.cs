using Entities.Models;
using Entities.DTOs;
using Repositories.Contracts;
using Services.Contracts;
using AutoMapper;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            Product product=_mapper.Map<Product>(productDto);
            _manager.Product.Create(product);
            _manager.Save();
        }

        public void UpdateProduct(Product product)
        {
            var value = _manager.Product.GetOneProduct(product.ProductId, true);
            value.ProductName = product.ProductName;
            value.Price = product.Price;
            _manager.Save();
        }

        public void DeleteProduct(int id)
        {
            Product product = GetOneProduct(id, false);
            if (product is not null)
            {
                _manager.Product.DeleteProduct(product);
                _manager.Save();
            }
            /*Aşağıdaki şekilde de kullanılabilir.
                Product product=GetOneProduct(id, false) ?? new Product();
                _manager.Product.DeleteProduct(product);
            */
        }

        public IEnumerable<Product> GetAllProducts(bool trachChanges)
        {
            return _manager.Product.GetAllProducts(trachChanges);
        }

        public Product? GetOneProduct(int id, bool trachChanges)
        {
            var value = _manager.Product.GetOneProduct(id, trachChanges);
            if (value is null)
                throw new Exception("Product not found!");
            return value;
        }
    }
}