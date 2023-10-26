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
       [ Display(Name = "Numero do Evento")]
        public int? IdEvento { get; set; }

        [Required]
        [Display(Name = "Numero usuario")]
        public int? IdUsuario{ get; set; }

        [Required]
        public int Quantidade { get; set; }

        [ForeignKey("IdEvento")]
        [OnDelete(DeleteBehavior.NoAction)]
        public Evento Evento { get; set; }

        [ForeignKey("IdUsuario")]
        [OnDelete(DeleteBehavior.NoAction)]
        public Usuario Usuario { get; set; }

    }
}

