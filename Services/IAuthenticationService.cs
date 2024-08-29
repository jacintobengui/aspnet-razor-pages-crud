using Microsoft.AspNetCore.Mvc;
using RazorCrud.Models;

namespace RazorCrud.Services
{
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(UserLoginDto userLoginDto);
        Task<bool> SignInAsync(UserRegisterDto userRegisterDto);
        Task LogOutAsync();
    }
}
