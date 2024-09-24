using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComuniQBD.Models
{
    [Table("PublicacaoUsuario")]
    public class PublicacaoUsuario
    {
        [Column("PublicacaoUsuarioId")]
        public int PublicacaoUsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        [Display(Name = "Usuario")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        [ForeignKey("PublicacaoId")]
        [Display(Name = "Publicacao")]
        public int PublicacaoId { get; set; }
        public Publicacao? Publicacao { get; set; }
    }
}
