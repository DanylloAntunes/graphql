using GraphQL;
using GraphQL.Types;
using System.Threading.Tasks;
using TesteGraphQL.Api.GraphQL.Query;

namespace TesteGraphQL.Api.GraphQL.Servico
{
    public abstract class ServicoGraphQL
    {
        protected abstract Schema ObtenhaSchema();

        public async Task<ExecutionResult> Execute(GraphQLQuery query)
        {
            return await new DocumentExecuter().ExecuteAsync(execucao =>
            {
                execucao.Schema = this.ObtenhaSchema();
                execucao.Query = query.Query;
                execucao.OperationName = query.OperationName;
                execucao.Inputs = query.Variables.ToInputs(); 
            }).ConfigureAwait(false);
        }
    }
}
