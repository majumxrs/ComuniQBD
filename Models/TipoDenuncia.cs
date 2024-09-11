using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComuniQBD.Models
{
    [Table("TipoDenuncia")]
    public class TipoDenuncia
    {
        [Column("TipoDenunciaId")]
        [Display(Name = "Cod. do tipo da Denuncia")]
        public int TipoDenunciaId { get; set; }

        [Column("TipoDenunciaNome")]
        [Display(Name = "Tipo de Campanha")]
        public string TipoDenunciaNome { get; set; } = string.Empty;
    }
}
