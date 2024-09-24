using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComuniQBD.Models
{
    [Table("TipoPerfil")]
    public class TipoPerfil
    {
        [Column("TipoPerfilId")]
        [Display(Name = "Cód. do Tipo Perfil")]
        public int TipoPerfilId { get; set; }

        [Column("TipoPerfilNome")]
        [Display(Name = "Tipo do perfil")]
        public string TipoPerfilNome { get; set; } = string.Empty;
    }
}
