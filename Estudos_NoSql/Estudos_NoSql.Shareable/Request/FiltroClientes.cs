using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_NoSql.Shareable.Request
{
    public class FiltroClientes : FilterBase
    {
        public string Nome { get; set; } = default!;

        public int Idade { get; set; } = default!;
    }
}
