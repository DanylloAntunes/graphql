using GraphQL;
using GraphQL.Types;
using System.Threading.Tasks;
using TesteGraphQL.Interfaces.ContratosDeServicos.Dados;

namespace TesteGraphQL.GraphQL.Servico
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
