using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ComuniQBD.Models
{
    [Table("Cidade")]
    public class Cidade
    {
        [Column("CidadeId")]
        [Display(Name = "código da cidade")]
        public int CidadeId { get; set; }

        [Column("CidadeNome")]
        [Display(Name = "Nome do Nome")]
        public string CidadeNome { get; set; } = string.Empty;

    }
}
