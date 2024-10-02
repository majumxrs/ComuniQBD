using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComuniQBD.Models
{
    [Table("Campanha")]
    public class Campanha
    {
        [Column("CampanhaId")]
        [Display(Name = "Cod. do Campanha")]
        public int CampanhaId { get; set; }

        [Column("CampanhaTitulo")]
        [Display(Name = "Titulo da campanha")]
        public string CampanhaTitulo { get; set; } = string.Empty;

        [Column("CampanhaMidia")]
        [Display(Name = "Mídia da campanha")]
        public byte[]? CampanhaMidia { get; set; } 

        [Column("CampanhaDescricao")]
        [Display(Name = "Descrição da campanha")]
        public string CampanhaDescricao { get; set; } = string.Empty;

        [ForeignKey("TipoCampanhaId")]
        [Display(Name = "Tipo da Campanha")]
        public int TipoCampanhaId { get; set; }
        public TipoCampanha? TipoCampanha { get; set; }

        [ForeignKey("CidadeId")]
        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }
        public Cidade? Cidade { get; set; }

        [NotMapped]
        public string ExibicaoImg { get; set; } = string.Empty;
    }
}
