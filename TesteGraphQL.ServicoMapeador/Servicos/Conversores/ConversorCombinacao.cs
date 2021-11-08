using System;
using System.Collections.Generic;
using System.Linq;
using TesteGraphQL.Interfaces.ContratosDeServicos.Dados;
using TesteGraphQL.Negocio.Objetos;
using TesteGraphQL.ServicoMapeador.Infraestrutura;

namespace TesteGraphQL.ServicoMapeador.Servicos.Conversores
{
    public class ConversorCombinacao : IConversor<DtoCombinacao, Combinacao>
    {
        public DtoCombinacao ConverteParaDto(Combinacao objeto)
        {
            var dto = new DtoCombinacao();

            dto.NumeroAlvo = objeto.NumeroAlvo;
            dto.Data = objeto.Data;

            if (objeto.Pontuacoes != null)
            {
                dto.Pontuacoes = objeto.Pontuacoes.Select(pontuacao => pontuacao.valor).ToList();
            }

            return dto;
        }

        public Combinacao ConverteParaObjeto(DtoCombinacao dto)
        {
            var objeto = new Combinacao();

            objeto.NumeroAlvo = dto.NumeroAlvo;
            objeto.Pontuacoes = ObtenhaListaDePontuacao(dto.Pontuacoes);

            CarregaIdentificadores(objeto);

            return objeto;
        }

        public List<Pontuacao> ObtenhaListaDePontuacao(List<int> listaDePontuacao)
        {
            return listaDePontuacao.Select(valor => new Pontuacao() { valor = valor }).ToList();
        }

        private void CarregaIdentificadores(Combinacao objeto)
        {
            objeto.Id = ObtenhaGuid(objeto.Id);

            objeto.Pontuacoes.ForEach(item =>
            {
                item.Id = ObtenhaGuid(item.Id);
                item.IdCombinacao = objeto.Id;
            });
        }

        private Guid ObtenhaGuid(Guid idObjeto)
        {
            if (idObjeto == Guid.Empty)
            {
                return Guid.NewGuid();
            }

            return idObjeto;
        }
    }
}
