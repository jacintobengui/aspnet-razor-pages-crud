
using Microsoft.AspNetCore.Identity;

namespace RazorCrud.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            if (! await _roleManager.RoleExistsAsync("User"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                role.ConcurrencyStamp = Guid.NewGuid().ToString();

                IdentityResult result = await _roleManager.CreateAsync(role);
            }

            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                role.ConcurrencyStamp = Guid.NewGuid().ToString();

                IdentityResult result = await _roleManager.CreateAsync(role);
            }

            if (!await _roleManager.RoleExistsAsync("Gerente"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Gerente";
                role.NormalizedName = "GERENTE";
                role.ConcurrencyStamp = Guid.NewGuid().ToString();

                IdentityResult result = await _roleManager.CreateAsync(role);
            }
        }

        public async Task SeedUsersAsync()
        {
            if (await _userManager.FindByEmailAsync("user@gmail.com") == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "User";
                user.Email = "user@gmail.com";
                user.NormalizedUserName = "USER";
                user.NormalizedEmail = "USER@GMAIL.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = await _userManager.CreateAsync(user, "Uu123456#");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }
            }

            if (await _userManager.FindByEmailAsync("gerente@gmail.com") == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "Gerente";
                user.Email = "gerente@gmail.com";
                user.NormalizedUserName = "GERENTE";
                user.NormalizedEmail = "GERENTE@GMAIL.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = await _userManager.CreateAsync(user, "Uu123456#");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Gerente");
                }
            }

            if (await _userManager.FindByEmailAsync("admin@gmail.com") == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "Admin";
                user.Email = "admin@gmail.com";
                user.NormalizedUserName = "ADMIN";
                user.NormalizedEmail = "ADMIN@GMAIL.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = await _userManager.CreateAsync(user, "Uu123456#");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
