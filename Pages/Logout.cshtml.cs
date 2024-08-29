using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrud.Models;
using RazorCrud.Services;
using System.Security.Claims;

namespace RazorCrud.Pages
{
    public class LogoutModel(IAuthenticationService authenticationService) : PageModel
    {
        public UserProfile UserInfo { get; set; } = new();

        public void OnGet()
        {
            UserInfo.UserName = User.FindFirst(ClaimTypes.Name)!.Value;
            UserInfo.Email = User.FindFirst(ClaimTypes.Email)!.Value;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await authenticationService.LogOutAsync();
            return RedirectToPage("Index");
        }
    }
}
