using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnotaCar.Models
{
    public class TipoCombustivel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        public List<Veiculo> Veiculos { get; set; }
    }
}
