using Backend_Mobile.Entities;
using Backend_Mobile.Repositories.ProductRepository;
using Backend_Mobile.Services.ProductService;
using Microsoft.EntityFrameworkCore;

namespace Backend_Mobile.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> AddProduct(Product product)
        {
            return await _productRepository.AddProduct(product);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            return await _productRepository.UpdateProduct(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _productRepository.DeleteProduct(id);
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }
        public async Task<List<Product>> GetProductByPageAndLimit(int page, int itemByPage)
         {
            return await _productRepository.GetProductByPageAndLimit(page, itemByPage);
         }


}
}