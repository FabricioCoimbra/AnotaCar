using System.ComponentModel.DataAnnotations;

namespace AnotaCar.Models
{
    public class PostoCombustivel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Nome { get; set; }

        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
