using Microsoft.EntityFrameworkCore;
using TesteGraphQL.ServicoMapeador.Mapeadores.Mapeamento;

namespace TesteGraphQL.ServicoMapeador.Infraestutura
{
    public class ContextoBD : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("TesteAudacesBD");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CombinacaoMap());
            modelBuilder.ApplyConfiguration(new PontuacaoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
