using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComuniQBD.Models
{
    [Table("Comentario")]
    public class Comentario
    {
        [Column("ComentarioId")]
        [Display(Name = "código do Comentario")]
        public int ComentarioId { get; set; }

        [Column("ComentarioTexto")]
        [Display(Name = "Incira seu comentario")]
        public string ComentarioTexto { get; set; } = string.Empty;

        [ForeignKey("UsuarioId")]
        [Display(Name = "Usuario")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
