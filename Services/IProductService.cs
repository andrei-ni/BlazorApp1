using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public interface IProductService
    {
        string Message { get; set; }
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
        Task<Product> GetProductByIdAsync(int id);
        Task<List<Product>> GetAllProductsAsync();
    }
}
