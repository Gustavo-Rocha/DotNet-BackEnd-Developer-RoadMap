using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_NoSql.Shareable.Response
{
    public class ClienteResponse
    {
      
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Rua { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public DateTime DiasAluguelFilme { get; set; }

        public List<FilmeResponse> Filme { get; set; }
    }
}
