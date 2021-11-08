using GraphQL.Types;
using TesteGraphQL.Api.GraphQL.Query;
using TesteGraphQL.Api.GraphQL.Servico;

namespace TesteGraphQL.Api.GraphQL
{
    public class ServicoGraphQLCombinacao : ServicoGraphQL
    {
        private CombinacaoQuery query;

        public ServicoGraphQLCombinacao(CombinacaoQuery query)
        {
            this.query = query;
        }

        protected override Schema ObtenhaSchema()
        {
            return new Schema()
            {
                Query = this.query
            };
        }
    }
}
