using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComuniQBD.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("UsuarioId")]
        [Display(Name = "Cod. do Usuario")]
        public int UsuarioId { get; set; }

        [Column("UsuarioNome")]
        [Display(Name = "Nome")]
        public string UsuarioNome { get; set; } = string.Empty;

        [Column("UsuarioSobrenome")]
        [Display(Name = "Sobrenome")]
        public string UsuarioSobrenome { get; set; } = string.Empty;

        [Column("UsuarioApelido")]
        [Display(Name = "Apelido")]
        public string UsuarioApelido { get; set; } = string.Empty;

        [Column("UsuarioEmail")]
        [Display(Name = "Email")]
        public string UsuarioEmail { get; set; } = string.Empty;

        [Column("UsuarioTelefone")]
        [Display(Name = "Telefone")]
        public int UsuarioTelefone { get; set; }

        [Column("UsuarioCPF")]
        [Display(Name = "CPF")]
        public string UsuarioCPF { get; set; } = string.Empty;

        [Column("UsuarioCEP")]
        [Display(Name = "CEP")]
        public int UsuarioCEP { get; set; }

        [Column("UsuarioCidade")]
        [Display(Name = "Cidade")]
        public string UsuarioCidade { get; set; } = string.Empty;

        [Column("UsuarioBairro")]
        [Display(Name = "Bairro")]
        public string UsuarioBairro { get; set; } = string.Empty;

        [Column("UsuarioEstado")]
        [Display(Name = "Estado")]
        public string UsuarioEstado { get; set; } = string.Empty;

        [Column("UsuarioSenha")]
        [Display(Name = "Senha")]
        public string UsuarioSenha { get; set; } = string.Empty;

        [Column("UsuarioFoto")]
        [Display(Name = "Foto do Usuário")]
        public byte[]? UsuarioFoto { get; set; }

        [ForeignKey("TipoPerfilId")]
        public int TipoPerfilId { get; set; }
        public TipoPerfil? TipoPerfil { get; set; }

        [NotMapped]
        public string ExibicaoImg { get; set; } = string.Empty;
    }
}
