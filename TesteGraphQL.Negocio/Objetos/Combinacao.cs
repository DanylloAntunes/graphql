using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteGraphQL.Negocio.Objetos
{
    public class Combinacao
    {
        public Guid Id { get; set; }

        public List<Pontuacao> Pontuacoes { get; set; }

        public int NumeroAlvo { get; set; }

        public DateTime Data { get; set; }

        public List<Pontuacao> ObtenhaResultado() 
        {
            var resultado = new List<Pontuacao>();

            if (this.InformacoesValidas())
            {
                resultado = this.ObtenhaCombinacao();
                this.Data = DateTime.Now;
            }

            return resultado;
        }

        private List<Pontuacao> ObtenhaCombinacao()
        {
            var valorTotal = 0;
            var valorDiferenca = this.NumeroAlvo;
            var listaResultado = new List<Pontuacao>();

            while (true)
            {
                var itemMaior = this.Pontuacoes.OrderByDescending(pontuacao => pontuacao.valor)
                                               .FirstOrDefault(pontuacao => pontuacao.valor <= valorDiferenca);

                listaResultado.Add(itemMaior);

                valorDiferenca -= itemMaior.valor;
                valorTotal = listaResultado.Sum(pontuacao => pontuacao.valor);

                if (valorTotal > this.NumeroAlvo || listaResultado.Count > this.Pontuacoes.Count)
                {
                    return new List<Pontuacao>();
                }
                else if (valorTotal == this.NumeroAlvo)
                {
                    return listaResultado;
                }
            }

        }
        private bool InformacoesValidas()
        {
            return this.Pontuacoes != null && this.Pontuacoes.Count > 0 && this.NumeroAlvo > 0;
        }
    }
}