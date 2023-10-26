using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPass1.Models
{
    [Table("Ingressos")]
    public class Ingresso
    {
        [Key]
        public int Id { get; set; }

        [Required]
       [ Display(Name = "Nome do Evento")]
        public int EventoId { get; set; }

        [Required]
        [Display(Name = "Nome do Espectador")]
        public int UsuarioId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [ForeignKey("EventoId")]
        [OnDelete(DeleteBehavior.NoAction)]
        public Evento Evento { get; set; }

        [ForeignKey("UsuarioId")]
        [OnDelete(DeleteBehavior.NoAction)]
        public Usuario Usuario { get; set; }

    }
}

