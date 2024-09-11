using Microsoft.EntityFrameworkCore;

namespace ComuniQBD.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        //public DbSet<Produto> Produto { get; set; }
        //public DbSet<TipoProduto> TipoProduto { get; set; }
        //public DbSet<EntradaeSaida> EntradaeSaida { get; set; }
        //public DbSet<TipoMovimentacao> TipoMovimentacao { get; set; }
    }
}
