using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TesteGraphQL.Negocio;
using TesteGraphQL.Negocio.Interfaces;
using TesteGraphQL.Negocio.Objetos;

namespace TesteGraphQL.Negocio.Validadores
{
    public class ValidacoesCombinacao : ValidacoesObjeto<Combinacao>
    {
        public override void AssineRegrasComuns()
        {
            this.AssineValidacaoPontuacao();
            this.AssineValidacaoNumeroAlvo();
        }

        public void AssineValidacaoPontuacao()
        {
            RuleFor(combinacao => combinacao.Pontuacoes)
                    .NotEmpty()
                    .Must((combinacao, lista) => !(lista == null || lista.Count == 0))
                    .WithMessage("Informe as pontuações.");
        }

        public void AssineValidacaoNumeroAlvo()
        {
            RuleFor(combinacao => combinacao.NumeroAlvo)
                    .NotEmpty()
                    .NotEqual(0)
                    .WithMessage("Informe o número alvo.");
        }
    }
}
