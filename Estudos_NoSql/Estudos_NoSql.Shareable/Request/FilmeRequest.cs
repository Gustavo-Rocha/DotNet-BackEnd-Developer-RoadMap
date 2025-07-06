using MediatR;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_NoSql.Shareable.Request;

    public record class FilmeRequest(FilmeRequestBody FilmeBodyRequest) : IRequest<Result>;

    public record class FilmeRequestBody
    {
        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string Duracao { get; set; }

        public string Ano { get; set; }

        public int Quantidade { get; set; }

    }

