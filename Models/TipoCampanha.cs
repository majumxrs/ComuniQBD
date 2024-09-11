using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComuniQBD.Models
{
    [Table("TipoCampanha")]

    public class TipoCampanha
    {
        [Column("TipoCampanhaId")]
        [Display(Name = "Cod. do tipo da Campanha")]
        public int TipoCampanhaId { get; set; }

        [Column("TipoCampanhaNome")]
        [Display(Name = "Tipo da campanha")]
        public string TipoCampanhaNome { get; set; } = string.Empty;
    }
}
