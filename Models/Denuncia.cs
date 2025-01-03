﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComuniQBD.Models
{
    [Table("Denuncia")]
    public class Denuncia
    {
        [Column("DenunciaId")]
        [Display(Name = "código da Denuncia")]
        public int DenunciaId { get; set; }

        [Column("DenunciaTitulo")]
        [Display(Name = "Título da Denúncia")]
        public string DenunciaTitulo { get; set; } = string.Empty;

        [Column("DenunciaMidia")]
        [Display(Name = "Foto da Denúncia")]
        public string? DenunciaMidia { get; set; } = string.Empty;

        [Column("DenunciaDescricao")]
        [Display(Name = "Descrição da denúncia")]
        public string DenunciaDescricao { get; set; } = string.Empty;

        [ForeignKey("TipoDenunciaId")]
        [Display(Name = "Tipo da Denúncia")]
        public int TipoDenunciaId { get; set; }
        public TipoDenuncia? TipoDenuncia { get; set; }

        [ForeignKey("BairroId")]
        [Display(Name = "Bairro")]
        public int BairroId { get; set; }
        public Bairro? Bairro { get; set; }
    }
}
