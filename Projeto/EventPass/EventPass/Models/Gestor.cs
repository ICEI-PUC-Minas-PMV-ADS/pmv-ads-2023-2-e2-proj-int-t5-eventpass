using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPass.Models
{
    public enum TipoGestor
    {
        Gestor
    }

    [Table("Gestor")]
    public class Gestor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome!")]        
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o CNPJ!")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o e-mail!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a senha!")]

        public string Senha { get; set;}

        [Required(ErrorMessage = "Obrigatório confirmar a senha!")]
        [Display(Name = "Confirmar senha")]
        public string ConfirmarSenha { get; set;}

       
        [Display(Name = "Tipo de Usuário")]
        public TipoGestor Tipo { get; set; }

    }
}
