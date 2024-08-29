using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrud.Data;
using RazorCrud.Models;
using RazorCrud.Services;
using System.Security.Claims;

namespace RazorCrud.Pages
{
    //[Authorize(Roles = "User, Gerente, Admin")]
    [Authorize(Policy = "RequireUserGerenteAdminRoles")]
    public class RegisterProductsModel(IProductService productService) : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public Product product { get; set; } = new();

        public async Task<IActionResult> OnPost(Product product)
        {

            if (ModelState.IsValid)
            {
                product.UserId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

                await productService.CreateProduct(product);
                ViewData["AlertCreation"] = "Produto cadastrado com sucesso!";
                return Page();
            }

            return Page();
        }

        public void OnPostCloseAlert()
        {
            ViewData["AlertCreation"] = null;
        }
    }
}


