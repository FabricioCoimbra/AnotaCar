using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnotaCar.Models
{
    public class Marca
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
