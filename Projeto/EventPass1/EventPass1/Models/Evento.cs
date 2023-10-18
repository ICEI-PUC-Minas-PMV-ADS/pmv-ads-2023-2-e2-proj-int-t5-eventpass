using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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
        public string NomeEvento { get; set; }

        [Required(ErrorMessage = "Informe a data da realização")]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Informe a data e hora de realização")]
        [Display(Name = "Hora")]
        [DataType(DataType.Time)] // Anotação para hora
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Hora { get; set; }

        [Required(ErrorMessage = "Informe o número de ingressos disponíveis")]
        [Display(Name = "Total de ingressos")]
        public int TotalIngressos { get; set; }

        [Required(ErrorMessage = "Informe a descrição do evento")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o local do evento")]
        [Display(Name = "Local")]
        public string Local { get; set; }

        [Required(ErrorMessage = "Informe o número do Cnpj ")]
        [Display(Name = "CNPJ")]
        public int GestorId { get; set; }

        [ForeignKey("GestorId")]
        public Usuario Usuarios { get; set; }
    }
}
