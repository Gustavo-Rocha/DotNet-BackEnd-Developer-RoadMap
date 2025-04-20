using Estudos_GraphQL.Shareable.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_GraphQL.Shareable.Response
{
    public record class LivrosResponse(List<Dtos.LivroDto> Livro);
    
}
