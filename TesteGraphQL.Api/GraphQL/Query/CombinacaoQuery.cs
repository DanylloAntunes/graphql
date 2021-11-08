using GraphQL.Types;
using System;
using System.Collections.Generic;
using TesteGraphQL.Api.GraphQL.Type;
using TesteGraphQL.Interfaces.ContratosDeServicos.Dados;
using TesteGraphQL.Interfaces.ContratosDeServicos.Servicos;

namespace TesteGraphQL.Api.GraphQL.Query
{
    public class CombinacaoQuery: ObjectGraphType<object>
    {
        public CombinacaoQuery(IServicoCombinacao servico)
        {
            Field<ListGraphType<IntGraphType>>(
                "combinacao",
                arguments: new QueryArguments(new QueryArgument[]
                {
                    new QueryArgument<ListGraphType<IntGraphType>>{Name="pontuacoes"},
                    new QueryArgument<IntGraphType>{Name="numeroalvo"}
                }),
                resolve: context =>
                {
                    var pontuacoes = context.GetArgument<List<int>>("pontuacoes");
                    var numeroAlvo = context.GetArgument<int>("numeroalvo");
                    var dto = new DtoCombinacao() { Pontuacoes = pontuacoes, NumeroAlvo = numeroAlvo };

                    return servico.ResolvaCombinacao(dto);
                }
            );

            Field<ListGraphType<CombinacaoType>>(
                "combinacaoAll",
                arguments: new QueryArguments(new QueryArgument[]
                {
                      new QueryArgument<DateTimeGraphType>{Name="datainicial"},
                      new QueryArgument<DateTimeGraphType>{Name="datafinal"}
                }),
                resolve: context =>
                {
                    var dataInicio = context.GetArgument<DateTime>("datainicial");
                    var dataFim = context.GetArgument<DateTime>("datafinal");

                    return servico.ObtenhaListaDeCombinacao(dataInicio, dataFim);
                }
            );
        }
    }
}
