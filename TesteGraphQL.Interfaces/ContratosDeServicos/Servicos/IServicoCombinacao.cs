using System;
using System.Collections.Generic;
using TesteGraphQL.Interfaces.ContratosDeServicos.Dados;

namespace TesteGraphQL.Interfaces.ContratosDeServicos.Servicos
{
    public interface IServicoCombinacao
    {
        List<int> ResolvaCombinacao(DtoCombinacao dto);

        List<DtoCombinacao> ObtenhaListaDeCombinacao(DateTime dataInicio, DateTime dataFim);
    }
}
