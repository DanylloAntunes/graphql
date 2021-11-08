using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using TesteGraphQL.Negocio.Objetos;

namespace TesteGraphQL.Interfaces.ContratosDeServicos.Dados
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
