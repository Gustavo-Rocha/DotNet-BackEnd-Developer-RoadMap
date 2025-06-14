using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_Cache.Model
{
    public class LivroDto
    {
        public string Titulo { get; set; } = default!;

        public string Autor { get; set; } = default!;

        public DateTime AnoPublicacao { get; set; }

    }
}
