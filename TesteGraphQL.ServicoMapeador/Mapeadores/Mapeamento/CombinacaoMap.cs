using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteGraphQL.Negocio;
using TesteGraphQL.Negocio.Objetos;

namespace TesteGraphQL.ServicoMapeador.Mapeadores.Mapeamento
{
    public class CombinacaoMap : IEntityTypeConfiguration<Combinacao>
    {
        public void Configure(EntityTypeBuilder<Combinacao> builder)
        {
            builder.Property(combinacao => combinacao.Id)
                .IsRequired();

            builder.HasMany(combinacao => combinacao.Pontuacoes)
                .WithOne(pontuacao => pontuacao.Combinacao)
                .HasForeignKey(pontuacao => pontuacao.IdCombinacao);

            builder.Property(combinacao => combinacao.NumeroAlvo)
                .IsRequired();

            builder.Property(combinacao => combinacao.Data)
                .IsRequired();
        }
    }
}