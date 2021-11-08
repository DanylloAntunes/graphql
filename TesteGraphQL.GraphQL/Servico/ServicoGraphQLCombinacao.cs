using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using TesteGraphQL.GraphQL.Servico;

namespace TesteGraphQL.GraphQL
{
    public class ServicoGraphQLCombinacao : ServicoGraphQL
    {
        protected override Schema ObtenhaSchema()
        {
            return new Schema()
            {
                Query = new CombinacaoQuery()
            };
        }
    }
}
