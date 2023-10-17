using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPass1.Models
{
    public enum TipoUsuario
    {
        Espectador,
        Gestor
    }

    [Table("Usuarios")]
    public class Usuario
    {
        [Required(ErrorMessage = "Obrigatório selecionar o tipo de usuário")]
        [Display(Name = "Tipo de Usuário")]
        public TipoUsuario Tipo { get; set; }

        [Key]
        [Display(Name = "Codigo usuario")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o seu Nome")]
        [Display(Name = "Nome do Usuário")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o seu Email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório digitar a sua senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatório digitar a confirmação da senha")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "As senhas não coincidem")]
        [Display(Name = "Confirmar a senha")]
        public string ConfirmarSenha { get; set; }


        [Required(ErrorMessage = "Obrigatório informar o seu CPF ou CNPJ ")]

        [Display(Name = "CPF ou CNPJ")]
        
        public string CPF { get; set; }

        public ICollection<Evento> Eventos { get; set; }

    }



}

