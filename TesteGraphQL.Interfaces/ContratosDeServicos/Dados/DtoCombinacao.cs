using System;
using System.Collections.Generic;
using System.Text;

namespace TesteGraphQL.Interfaces.ContratosDeServicos.Dados
{
    public class DtoCombinacao
    {
        public List<int> Pontuacoes { get; set; }

        public int NumeroAlvo { get; set; }

        public DateTime Data { get; set; }

        public List<int> Resultado { get; set; }
    }
}
