using System.ComponentModel.DataAnnotations;

namespace RazorCrud.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o preço do produto")]
        [Range(1, 9999999, ErrorMessage = "Inform um valor válido")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Informe a quantidade do produto")]
        [Range(1, 9999999, ErrorMessage = "Inform um valor válido")]
        public int Quantity { get; set; }

        public DateTime CreatedDate { get; init; }

        public Product()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
    }
}
