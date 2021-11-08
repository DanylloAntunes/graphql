using System;
using System.Collections.Generic;
using TesteGraphQL.Negocio.Objetos;

namespace TesteGraphQL.Negocio.Interfaces
{
    public interface IRepositorioCombinacao : IRepositorio<Combinacao>
    {
        IList<Combinacao> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim);
    }
}
