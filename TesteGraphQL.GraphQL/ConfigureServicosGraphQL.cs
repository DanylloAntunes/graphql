using Microsoft.Extensions.DependencyInjection;
using TesteGraphQL.Interfaces.ContratosDeServicos.Servicos;
using TesteGraphQL.ServicoMapeador.Infraestutura;
using TesteGraphQL.ServicoMapeador.Servicos;

namespace TesteGraphQL.GraphQL
{
    public class ConfigureServicosGraphQL
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ServicoGraphQLCombinacao>();

            services.AddScoped<IServicoCombinacao, ServicoCombinacao>();

            services.AddSingleton<ContextoBD>();
        }
    }
}
