using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPass1.Models
{
    [Table("Ingressos")]
    public class Ingresso
    {
        [Key]
        public int? Id { get; set; }

        [Required]
       [ Display(Name = "Nome do Evento")]
        public int? IdEvento { get; set; }

        [Required]
        [Display(Name = "Nome do usuario")]
        public int IdUsuario{ get; set; }

        public int Status { get; set; }

        [Required]
        [Display(Name = "Ingresso")]
        public int Quantidade { get; set; }

        
        public Evento Evento { get; set; }

        
        public Usuario Usuario { get; set; }

    }
}

