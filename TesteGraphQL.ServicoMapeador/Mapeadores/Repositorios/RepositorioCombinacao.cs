using System;
using System.Collections.Generic;
using System.Linq;
using TesteGraphQL.Negocio.Interfaces;
using TesteGraphQL.Negocio.Objetos;
using TesteGraphQL.ServicoMapeador.Infraestutura;

namespace TesteGraphQL.ServicoMapeador.Mapeadores.Repositorios
{
    public class RepositorioCombinacao : Repositorio<Combinacao>, IRepositorioCombinacao
    {
        public RepositorioCombinacao(ContextoBD contexto) : base(contexto)
        {
        }

        public IList<Combinacao> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return this.Contexto.Set<Combinacao>().Where(combinacao => combinacao.Data.Date >= dataInicio && combinacao.Data.Date <= dataFim).ToList();
        }
    }
}
