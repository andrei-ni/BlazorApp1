using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }

        public string Message { get; set; } = string.Empty;

        public async Task<Product> CreateProductAsync(Product product)
        {
            if (product.Name != string.Empty || product.Description != string.Empty)
            {
                _context.Products.Add(product);
            }
            var result = await _context.SaveChangesAsync();
            if(result == 1)
            {
                Message = "Product was added successfully.";
            }
            else
            {
                Message = "Error adding product, try again.";
            }
            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var dbProduct = await _context.Products.FindAsync(id);
            if(dbProduct is not null)
            {
                _context.Remove(dbProduct);
            }
            var result = await _context.SaveChangesAsync();
            if (result == 1)
            {
                Message = "Product was deleted.";
            }
            else
            {
                Message = "Error deleting product, try again.";
            }
            return true;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var dbProducts = await _context.Products.ToListAsync();
            return dbProducts;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(dbProduct => dbProduct.Id == id);
            return dbProduct;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if(dbProduct is not null)
            {
                dbProduct.Name = product.Name;
                dbProduct.Description = product.Description;
            }
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
