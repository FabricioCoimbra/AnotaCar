using System;
using System.ComponentModel;

namespace AnotaCar.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public TipoServico TipoServico { get; set; }
        [DisplayName("Tipo de serviço")]
        public int TipoServicoId { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public Veiculo Veiculo { get; set; }
        public int VeiculoId { get; set; }
        [DisplayName("Odômetro")]
        public int Odometro { get; set; }
        public string Observacao { get; set; }
    }
}
