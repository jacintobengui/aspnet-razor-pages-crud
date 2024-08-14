using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrud.Models;
using RazorCrud.DataBase;

namespace RazorCrud.Pages
{
    public class RegisterProductsModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public Product product { get; set; } = default!;

        public IActionResult OnPost(Product product)
        {

            if (ModelState.IsValid)
            {
                Product newProd = new()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity
                };

                Database.Products.Add(newProd);
            }

            return RedirectToPage("Index");
        }
    }

}
