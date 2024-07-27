using Microsoft.EntityFrameworkCore;
using SimpleMicroservice.Models;

namespace SimpleMicroservice.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product is null.");
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return "Product added successfully.";
        }

        public async Task<string> UpdateProduct(int id, Product productUpdate)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return "Product not found.";
            }

            product.Name = productUpdate.Name;
            product.Price = productUpdate.Price;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return "Product updated successfully.";
        }
     

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<string> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return "Product not found.";
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return "Product deleted successfully.";
        }
    }
}