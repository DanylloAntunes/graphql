using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteGraphQL.Negocio.Objetos;

namespace TesteGraphQL.ServicoMapeador.Mapeadores.Mapeamento
{
    public class PontuacaoMap : IEntityTypeConfiguration<Pontuacao>
    {
        public void Configure(EntityTypeBuilder<Pontuacao> builder)
        {
            builder.Property(pontuacao => pontuacao.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(pontuacao => pontuacao.IdCombinacao)
                .IsRequired();

            builder.Property(pontuacao => pontuacao.valor)
                .IsRequired();
        }
    }
}
