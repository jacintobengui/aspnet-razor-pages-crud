using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrud.Models;
using RazorCrud.Services;

namespace RazorCrud.Pages
{
    public class SignInModel(IAuthenticationService authenticationService) : PageModel
    {
        [BindProperty]
        public UserRegisterDto User { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(UserRegisterDto User)
        {
            if (ModelState.IsValid)
            {
                var result = await authenticationService.SignInAsync(User);

                if (result)
                    return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
