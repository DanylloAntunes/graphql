using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TesteGraphQL.Api.GraphQL;
using TesteGraphQL.Api.GraphQL.Query;

namespace TesteGraphQL.Api.Controllers
{
    [ApiController]
    [Route("graphql")]
    public class CombinacaoController : ControllerBase
    {
        private ServicoGraphQLCombinacao servico;

        public CombinacaoController(ServicoGraphQLCombinacao servico)
        {
            this.servico = servico;
        }

        [HttpPost]
        public IActionResult Post([FromBody] GraphQLQuery query)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var resultado = servico.Execute(query);

                    if (resultado.Result.Errors?.Count > 0)
                        return Ok(resultado.Result.Errors);

                    return Ok(resultado);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest();
        }
    }
}
