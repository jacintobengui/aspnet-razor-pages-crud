using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCrud.Data;
using RazorCrud.Models;
using RazorCrud.Services;

namespace RazorCrud.Pages
{
    [Authorize(Roles = "Gerente, Admin")]
    public class EditProductModel(IProductService productService) : PageModel
    {

        [BindProperty]
        public Product Product { get; set; } = new();

        public async Task DisplayProductAsync(string Id)
        {
            var product = await productService.GetProductById(new Guid(Id));

            Product.Id = product!.Id;
            Product.Name = product.Name;
            Product.Price = product.Price;
            Product.Quantity = product.Quantity;
        }

        public async Task<IActionResult> OnGet([FromRoute] string prodId)
        {
            if (!string.IsNullOrEmpty(prodId))
            {
                await DisplayProductAsync(prodId);
            }
            else
            {
                return NotFound();
            }

            return Page();
        }

        public async Task OnPost([FromRoute] string prodId)
        {
            if (ModelState.IsValid)
            {

                UpdateProductDto productDto =
                    new(Product.Name, Product.Price, Product.Quantity);

                await productService.UpdateProduct(new Guid(prodId), productDto);

                ViewData["AlertEdition"] = "Produto editado com sucesso!";

                await DisplayProductAsync(prodId);
            }
        }

        public void OnPostCloseAlert()
        {
            ViewData["AlertEdition"] = null;
        }
    }
}
