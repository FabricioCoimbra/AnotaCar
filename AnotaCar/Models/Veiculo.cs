using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnotaCar.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(500)]
        public string Modelo { get; set; }
        [Range(1884, 2500, ErrorMessage = "Informe m ano válido ou deixe em branco")]
        public int? Ano { get; set; }
        [MaxLength(10)]
        public string Placa { get; set; }
        [Range(2, 500, ErrorMessage = "Informe uma capacidade válida de combustível em litros!")]
        [DisplayName("Capacidade do Tanque (Em litros)")]
        public double CapacidadeTanque { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public int TipoVeiculoID { get; set; }
        public Marca Marca { get; set; }
        public int MarcaId { get; set; }
    }
}
