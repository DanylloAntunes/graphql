using NUnit.Framework;
using System;
using System.Collections.Generic;
using TesteGraphQL.Negocio;
using TesteGraphQL.Negocio.Objetos;
using System.Linq;

namespace TesteGraphQL.Teste
{
    public class CombinacaoTests
    {
        [Test]
        public void TestaCombinacaoValida()
        {

            var combinacao = new Combinacao()
            {
                Pontuacoes = ObtenhaListaDePontuacao(),
                NumeroAlvo = 48
            };

            var resultado = ObtenhaResultado(combinacao);

            Assert.AreEqual(true, resultado == "20,20,5,2");
        }

        [Test]
        public void TestaCombinacaoInvalido()
        {

            var combinacao = new Combinacao()
            {
                Pontuacoes = ObtenhaListaDePontuacao(),
                NumeroAlvo = 50
            };

            var resultado = ObtenhaResultado(combinacao);

            Assert.AreEqual(false, resultado == "20,20,5,2");
        }

        [Test]
        public void TestaCombinacaoQuantidadeRetorno()
        {
            var combinacao = new Combinacao()
            {
                Pontuacoes = new List<Pontuacao> { new Pontuacao() { valor = 1 } },
                NumeroAlvo = 5
            };

            Assert.AreEqual(false, combinacao.ObtenhaResultado().Any());
        }

        [Test]
        public void TestaCombinacaoSemListaDePontuacao()
        {

            var combinacao = new Combinacao()
            {
                Pontuacoes = new List<Pontuacao>(),
                NumeroAlvo = 50
            };

            Assert.AreEqual(false, combinacao.ObtenhaResultado().Any());
        }

        private string ObtenhaResultado(Combinacao combinacao)
        {
            return String.Join(",", combinacao.ObtenhaResultado().Select(pontuacao => pontuacao.valor));
        }

        private List<Pontuacao> ObtenhaListaDePontuacao()
        {
            return new List<Pontuacao>()
            {
                new Pontuacao() { valor = 5 },
                new Pontuacao() { valor = 20 },
                new Pontuacao() { valor = 2 },
                new Pontuacao() { valor = 1 }
            };
        }
    }
}