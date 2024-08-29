using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrud.Models;
using RazorCrud.Services;

namespace RazorCrud.Pages
{
    public class LoginModel(IAuthenticationService authenticationService) : PageModel
    {

        [BindProperty]
        public UserLoginDto User { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync(UserLoginDto User)
        {
            if (ModelState.IsValid)
            {
                var result = await authenticationService.LoginAsync(User);

                if (result)
                    return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
