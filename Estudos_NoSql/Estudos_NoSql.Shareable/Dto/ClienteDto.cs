using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_NoSql.Shareable.Dto
{
    public class ClienteDto
    {
        public string? Id { get; set; } = default!;

        public string Nome { get; set; } = default!;

        public string Cpf { get; set; } = default!;

        public string Rua { get; set; } = default!;

        public string Cep { get; set; } = default!;

        public string Bairro { get; set; } = default!;

        public string Cidade { get; set; } = default!;

        public string UF { get; set; } = default!;
    }
}
