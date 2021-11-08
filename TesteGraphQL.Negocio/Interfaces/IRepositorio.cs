using System.Collections;
using System.Collections.Generic;

namespace TesteGraphQL.Negocio.Interfaces
{
    public interface IRepositorio<TObj>
    {
        void Alterar(TObj objeto);
        void Remover(TObj objeto);
        void Salvar(TObj objeto);
        IList ObterTodos();
    }
}
