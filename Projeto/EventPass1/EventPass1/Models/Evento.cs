using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace EventPass.Models
{
    [Table("Evento")]
    public class Evento
    {
        [Key]
        public int IdEvento { get; set; }

        [Required(ErrorMessage ="Informe o nome do evento")]
        [Display(Name = "Nome do Evento")]
        public string nomeEvento { get; set; }
        [Required(ErrorMessage ="Informe a data e hora de realização")]
        [Display(Name = "Data e hora")]
        public DateTime dataHora { get; set; }
        [Required(ErrorMessage ="Informe o número de ingressos disponíveis")]
        [Display(Name = "Total de ingressos")]
        public int totalIngressos { get; set; }
        
        public string uf { get; set; }

        public string cidade { get; set; }

        public string bairro { get; set; }
        [Required(ErrorMessage ="Informe o CEP")]
        public string cep { get; set; }
        [Required(ErrorMessage ="Informe o número")]
        public int numero { get; set; }
    }
}
