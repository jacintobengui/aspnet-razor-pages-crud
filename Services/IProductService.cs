using Microsoft.AspNetCore.Mvc;
using RazorCrud.Models;

namespace RazorCrud.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();

        Task<Product> GetProductById(Guid prodId);

        Task UpdateProduct(Guid prodId, UpdateProductDto productDto);

        Task CreateProduct(Product product);

        Task DeleteProduct(Guid prodId);
    }
}
