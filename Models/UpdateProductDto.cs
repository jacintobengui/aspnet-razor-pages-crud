using System.ComponentModel.DataAnnotations;

namespace RazorCrud.Models
{
    public record UpdateProductDto
        (string Name, double Price, int Quatity);
}
