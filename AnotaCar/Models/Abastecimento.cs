using System.ComponentModel;

namespace AnotaCar.Models
{
    public class Abastecimento
    {
        public int Id { get; set; }
        public PostoCombustivel Posto { get; set; }
        [DisplayName("Posto")]
        public int PostoId { get; set; }
        [DisplayName("Odômetro")]
        public int Odometro { get; set; }
        public double Litros { get; set; }
        [DisplayName("Valor")]
        public double ValorLitro { get; set; }
        [DisplayName("Tanque cheio?")]
        public bool TanqueCheio { get; set; }
        public Veiculo Veiculo { get; set; }
        public int VeiculoId { get; set; }
        [DisplayName("Observação")]
        public string Observacao { get; set; }
    }
}
