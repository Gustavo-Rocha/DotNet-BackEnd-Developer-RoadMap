using Estudos_NoSql.Shareable.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_NoSql.Shareable.Response
{
    public record ListaClienteResponse(List<ClienteDto> ListaClienteDtos)
    {
    }
}
