using System;
using System.Collections.Generic;
using System.Text;

namespace TesteGraphQL.ServicoMapeador.Infraestrutura
{
    public interface IConversor<TDto, TObj>
    {
        TObj ConverteParaObjeto(TDto dto);
        TDto ConverteParaDto(TObj objeto);
    }
}
