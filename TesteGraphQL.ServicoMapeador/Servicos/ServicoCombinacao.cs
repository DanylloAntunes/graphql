using System;
using System.Collections.Generic;
using System.Linq;
using TesteGraphQL.Interfaces.ContratosDeServicos.Dados;
using TesteGraphQL.Interfaces.ContratosDeServicos.Servicos;
using TesteGraphQL.Negocio.Interfaces;
using TesteGraphQL.Negocio.Objetos;
using TesteGraphQL.Negocio.Validadores;
using TesteGraphQL.ServicoMapeador.Infraestrutura;
using TesteGraphQL.ServicoMapeador.Infraestutura;
using TesteGraphQL.ServicoMapeador.Mapeadores.Repositorios;
using TesteGraphQL.ServicoMapeador.Servicos.Conversores;

namespace TesteGraphQL.ServicoMapeador.Servicos
{
    public class ServicoCombinacao : Servico<DtoCombinacao, Combinacao>, IServicoCombinacao
    {
        public ServicoCombinacao(ContextoBD contexto) : base(contexto)
        {
        }

        public List<DtoCombinacao> ObtenhaListaDeCombinacao(DateTime dataInicio, DateTime dataFim)
        {
            var repositorio = (RepositorioCombinacao)ObtenhaRepositorio();
            var conversor = ObtenhaConversor();

            return repositorio.ObterPorPeriodo(dataInicio, dataFim)
                                .Select(combinacao => conversor.ConverteParaDto(combinacao)).ToList();
        }

        public List<int> ResolvaCombinacao(DtoCombinacao dto)
        {
            var conversor = this.ObtenhaConversor();
            var combinacao = conversor.ConverteParaObjeto(dto);
            var resultado = combinacao.ObtenhaResultado().Select(pontuacao => pontuacao.valor).ToList();
            var repositorio = this.ObtenhaRepositorio();

            this.Salvar(combinacao);

            return resultado;
        }

        protected override IConversor<DtoCombinacao, Combinacao> ObtenhaConversor()
        {
            return new ConversorCombinacao(); 
        }

        protected override IRepositorio<Combinacao> ObtenhaRepositorio()
        {
            return new RepositorioCombinacao(this.contexto);
        }

        protected override ValidacoesObjeto<Combinacao> ObtenhaValidador()
        {
            return new ValidacoesCombinacao();
        }
    }
}
