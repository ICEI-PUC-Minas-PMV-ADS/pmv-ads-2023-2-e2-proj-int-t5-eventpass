using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventPass1.Models
{
    [Table("Eventos")]
    public class Evento
    {
        [Key]
        public int IdEvento { get; set; }

        [Required(ErrorMessage = "Informe o nome do evento")]
        [Display(Name = "Nome do Evento")]
        public string nomeEvento { get; set; }

        [Required(ErrorMessage = "Informe a data e hora de realização")]
        [Display(Name = "Data e hora")]
        public DateTime dataHora { get; set; }
        [Required(ErrorMessage = "Informe o número de ingressos disponíveis")]
        [Display(Name = "Total de ingressos")]
        public int totalIngressos { get; set; }

        [Required(ErrorMessage = "Informe o número do Cnpj ")]
        [Display(Name = "Gestor")]
        public int GestorId { get; set; }

        [ForeignKey("GestorId")]
        public Usuario Usuarios { get; set; }



    }
}
