using System;
using System.Collections.Generic;
using System.Text;

namespace TesteGraphQL.Interfaces.ContratosDeServicos.Servicos
{
    public interface IServico<TDto, TObj>
        where TObj : class
        where TDto : class
    {
        void Salvar(TDto dto);
    }
}
