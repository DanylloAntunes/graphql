using GraphQL.Types;
using TesteGraphQL.Interfaces.ContratosDeServicos.Dados;

namespace TesteGraphQL.Api.GraphQL.Type
{
    public class CombinacaoType: ObjectGraphType<DtoCombinacao>
    {
        public CombinacaoType()
        {
            Name = "Combinacao";
            Field(x => x.Pontuacoes).Description("Sequência de pontuação");
            Field(x => x.NumeroAlvo).Description("Número alvo");
            Field(x => x.Data).Description("Data da consulta");
            Field(x => x.Resultado).Description("Resultado da combinação");
        }
    }
}
