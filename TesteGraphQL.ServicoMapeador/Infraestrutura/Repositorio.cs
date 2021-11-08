using System;
using System.Collections;
using System.Collections.Generic;
using TesteGraphQL.Negocio.Interfaces;

namespace TesteGraphQL.ServicoMapeador.Infraestutura
{
    public abstract class Repositorio<TObj> : IRepositorio<TObj> where TObj : class
    {
        protected ContextoBD Contexto { get; set; }

        public Repositorio(ContextoBD contexto)
        {
            this.Contexto = contexto;
        }

        public void Alterar(TObj objeto)
        {
            this.Contexto.Set<TObj>().UpdateRange(objeto);
            this.Contexto.SaveChanges();
        }

        public virtual TObj Consultar(Guid id)
        {
            return this.Contexto.Set<TObj>().Find(id);
        }

        public void Remover(TObj objeto)
        {
            this.Contexto.Set<TObj>().RemoveRange(objeto);
            this.Contexto.SaveChanges();
        }

        public IList ObterTodos()
        {
            var lista = new ArrayList();
            foreach(var objeto in this.Contexto.Set<TObj>())
            {
                lista.Add(objeto);
            }
            return lista;
        }

        public void Salvar(TObj objeto)
        {
            this.Contexto.Set<TObj>().Add(objeto);
            this.Contexto.SaveChanges();
        }
    }
}
