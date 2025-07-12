using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_NoSql.Shareable.Request
{
    public abstract class FilterBase
    {
        public int? QuantidadeItensPorPagina { get; set; } = default!;

        public int? Pagina { get; set; } = default!;
    }
}
