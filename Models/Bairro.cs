using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ComuniQBD.Models
{
    [Table("Bairro")]
    public class Bairro
    {
        [Column("BairroId")]
        [Display(Name = "código do Bairro")]
        public int BairroId { get; set; }

        [Column("BairroNome")]
        [Display(Name = "Nome do Bairro")]
        public string BairroNome { get; set; } = string.Empty;

        [ForeignKey("CidadeId")]
        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }
        public Cidade? Cidade { get; set; }

        [ForeignKey("EstadoId")]
        [Display(Name = "Estado")]
        public int EstadoId { get; set; }
        public Estado? Estado { get; set; }

    }
}
