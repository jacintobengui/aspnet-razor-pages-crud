using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RazorCrud.Models;

namespace RazorCrud.Services
{
    public class AuthenticationService
        (UserManager<IdentityUser> userManager, 
        SignInManager<IdentityUser> signInManager) 
        : IAuthenticationService
    {
        public async Task<bool> LoginAsync(UserLoginDto User)
        {
            try
            {
                var result = await signInManager.PasswordSignInAsync(User.UserName, User.Password, User.RememberMe, false);

                return result.Succeeded;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task LogOutAsync()
        {
            try
            {
                await signInManager.SignOutAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SignInAsync(UserRegisterDto userRegisterDto)
        {
            try
            {
                var user = new IdentityUser()
                {
                    UserName = userRegisterDto.UserName,
                    Email = userRegisterDto.Email
                };

                // Armazena os dados do usuário na tabela AspNetUsers
                var result = await userManager.CreateAsync(user, userRegisterDto.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
