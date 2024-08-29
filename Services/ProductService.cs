using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RazorCrud.Data;
using RazorCrud.Models;

namespace RazorCrud.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteProduct(Guid prodId)
        {
            try
            {
                var product = await _context.Products
                    .FirstOrDefaultAsync(x => x.Id == prodId);
                _context.Products.Remove(product!);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> GetProductById(Guid prodId)
        {
            try
            {
                var product = await _context.Products
                    .FirstOrDefaultAsync(x => x.Id == prodId);
                return product!;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Product>> GetProducts()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                return products;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateProduct(Guid prodId, UpdateProductDto productDto)
        {
            try
            {
                var product = await _context.Products
                    .FirstOrDefaultAsync(x => x.Id == prodId);

                if (product == null)
                    return;

                product.Name = productDto.Name;
                product.Price = productDto.Price;
                product.Quantity = productDto.Quatity;

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
