using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComuniQBD.Models
{
    [Table("Publicacao")]
    public class Publicacao
    {
        [Column("PublicacaoId")]
        [Display(Name = "código da publicaõ")]
        public int PublicacaoId { get; set; }

        [Column("PublicacaoTitulo")]
        [Display(Name = "Titulo da Publicação")]
        public string PublicacaoTitulo { get; set; } = string.Empty;

         [ForeignKey("BairroId")]
         [Display(Name = "Bairro")]
         public int BairroId { get; set; }
         public Bairro? Bairro { get; set; }

        [Column("PublicacaoMidia")]
        [Display(Name = "Imagem do Ocorrido")]
        public string? PublicacaoMidia { get; set; } = string.Empty;

        [Column("PublicacaoDescricao")]
        [Display(Name = "Descrição da publicação")]
        public string PublicacaoDescricao { get; set; } = string.Empty;

    }
}
