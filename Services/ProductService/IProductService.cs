using Backend_Mobile.Entities;

namespace Backend_Mobile.Services.ProductService
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
        Task<Product?> GetProductById(int id);
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetProductByPageAndLimit (int page, int limit);
    }
}