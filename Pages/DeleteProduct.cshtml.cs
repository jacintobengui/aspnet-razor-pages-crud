using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrud.DataBase;
using RazorCrud.Models;

namespace RazorCrud.Pages
{
    public class DeleteProductModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; } = new();

        public IActionResult OnGet([FromRoute] string prodId)
        {
            Guid productId = new Guid(prodId);

            if(productId == Guid.Empty)
                return NotFound();

            var product = Database.Products
                .FirstOrDefault(x => x.Id == productId);

            Product.Id = product.Id;
            Product.Name = product.Name;
            Product.Price = product.Price;
            Product.Quantity = product.Quantity;

            return Page();
        }

        public IActionResult OnPost([FromRoute] string prodId)
        {
            var product = Database.Products
                .FirstOrDefault(x => x.Id == new Guid(prodId));

            Database.Products.Remove(product!);

            return RedirectToPage("Index");
        }
    }
}
