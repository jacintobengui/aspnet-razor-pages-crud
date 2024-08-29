using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace RazorCrud.Models;

public class UserLoginDto
{
    [Required(ErrorMessage = "O noe de usuário é obrigatório!")]
    public string? UserName { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Display(Name = "Lembrar-me")]
    public bool RememberMe { get; set; }
}
