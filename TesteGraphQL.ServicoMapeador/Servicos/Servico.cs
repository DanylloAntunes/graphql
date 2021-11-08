using FluentValidation;
using System;
using System.Linq;
using TesteGraphQL.Interfaces.ContratosDeServicos.Servicos;
using TesteGraphQL.Negocio.Interfaces;
using TesteGraphQL.Negocio.Validadores;
using TesteGraphQL.ServicoMapeador.Infraestrutura;
using TesteGraphQL.ServicoMapeador.Infraestutura;

namespace TesteGraphQL.ServicoMapeador.Servicos
{
    public abstract class Servico<TDto, TObj> : IServico<TDto, TObj>
        where TObj : class
        where TDto : class
    {

        protected Servico(ContextoBD contexto)
        {
            this.contexto = contexto;
        }

        protected ContextoBD contexto;

        protected abstract IConversor<TDto, TObj> ObtenhaConversor();

        protected abstract ValidacoesObjeto<TObj> ObtenhaValidador();

        protected abstract IRepositorio<TObj> ObtenhaRepositorio();


        public void Salvar(TDto dto)
        {
            var objeto = this.ObtenhaConversor().ConverteParaObjeto(dto);

            this.Salvar(objeto);
        }

        protected void Salvar(TObj objeto)
        {
            this.ExecuteValidacaoInsercao(objeto);

            this.ObtenhaRepositorio().Salvar(objeto);
        }

        private void ExecuteValidacao(TObj objeto, IValidator validador)
        {
            var context = new ValidationContext<TObj>(objeto);
            var retornoValidacao = validador.Validate(context);

           if (!retornoValidacao.IsValid)
           {
              throw new Exception(retornoValidacao.Errors.FirstOrDefault().ErrorMessage);
           }
        }
        private void ExecuteValidacaoInsercao(TObj objeto)
        {
            var validacao = this.ObtenhaValidador();

            validacao.AssineRegraDeInsercao();

            this.ExecuteValidacao(objeto, validacao);
        }
    }
}
