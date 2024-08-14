using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrud.Models;
using RazorCrud.DataBase;

namespace RazorCrud.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; } = new();

        public void OnGet()
        {
            var products = Database.Products.OrderByDescending(x => x.CreatedDate);

            if(products.Any())
            Products.AddRange(products);
        }

    }
}
