using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_GraphQL.Shareable.Request.GraphQLInputs
{
    public class LivroInput
    {
        public string Titulo { get; set; } = default!;
        public string Autor { get; set; } = default!;
        public string AnoPublicacao { get; set; }
    }
}
