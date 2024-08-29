using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCrud.Data;
using RazorCrud.Models;
using RazorCrud.Services;

namespace RazorCrud.Pages
{
    [Authorize(Roles = "Admin")]
    public class DeleteProductModel(IProductService productService) : PageModel
    {
        
        [BindProperty]
        public Product Product { get; set; } = new();

        public async Task<IActionResult> OnGet([FromRoute] string prodId)
        {
            if (!String.IsNullOrEmpty(prodId))
            {
                var product = await productService.GetProductById(new Guid(prodId));

                if (product != null)
                {
                    Product.Id = product.Id;
                    Product.Name = product.Name;
                    Product.Price = product.Price;
                    Product.Quantity = product.Quantity;
                }
            }
            else
            {
                return NotFound();
            }

            return Page();
        }

        public async Task OnPost([FromRoute] string prodId)
        {
            await productService.DeleteProduct(new Guid(prodId));

            ViewData["AlertDeletion"] = "Produto excluído com sucesso!";
        }

        public IActionResult OnPostCloseAlert()
        {
            ViewData["AlertDeletion"] = null;
            return RedirectToPage("Index");
        }
    }
}
