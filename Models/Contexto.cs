using Microsoft.EntityFrameworkCore;

namespace ComuniQBD.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Denuncia> Denuncia { get; set; }
        public DbSet<TipoDenuncia> TipoDenuncia { get; set; }
        public DbSet<Campanha> Campanha { get; set; }
        public DbSet<TipoCampanha> TipoCampanha { get; set; }
        public DbSet<Bairro> Bairro { get; set; }
        public DbSet<Publicacao> Publicacao { get; set; }
    }
}
