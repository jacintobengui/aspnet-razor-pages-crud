using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RazorCrud.Data;
using RazorCrud.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(connectionString);
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireUserGerenteAdminRoles", 
        policy => policy.RequireRole("User", "Gerente", "Admin"));
});

// Configurando a complexidade da senha
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
});

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ISeedUserRoleInitial,  SeedUserRoleInitial>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapRazorPages();

await CriarPerfisUsuariosAsync(app);

app.UseAuthentication();
app.UseAuthorization();

app.Run();

async Task CriarPerfisUsuariosAsync(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<ISeedUserRoleInitial>();
        await service.SeedRolesAsync();
        await service.SeedUsersAsync();
    }
}
