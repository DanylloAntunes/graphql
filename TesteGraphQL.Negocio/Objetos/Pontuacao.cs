using System;
using System.Collections.Generic;
using System.Text;

namespace TesteGraphQL.Negocio.Objetos
{
    public class Pontuacao
    {
        public Guid Id { get; set; }

        public int valor { get; set; }

        public Guid IdCombinacao { get; set; }

        public virtual Combinacao Combinacao { get; set; }
    }
}
