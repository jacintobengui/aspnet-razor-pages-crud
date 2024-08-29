using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCrud.Data;
using RazorCrud.Models;
using RazorCrud.Services;
using System.Security.Claims;

namespace RazorCrud.Pages
{
    [Authorize]
    [AllowAnonymous]
    public class IndexModel(IProductService productService) : PageModel
    {
        public List<Product> Products { get; set; } = new();

        public async Task OnGet()
        {
            //Guid UserId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var products = await productService.GetProducts();

            // Filtrando apenas produtos do usuário logado

            //var userProducts = products
            //    .Where(x => x.UserId == UserId)
            //    .OrderByDescending(x => x.CreatedDate);

            if(products.Any())
            Products.AddRange(products.OrderByDescending(x => x.CreatedDate));
        }

        

    }
}
