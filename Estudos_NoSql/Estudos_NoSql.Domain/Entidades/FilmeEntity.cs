using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_NoSql.Domain.Entidades
{
    public class FilmeEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string Duracao { get; set; }

        public string Ano { get; set; }

        public int Quantidade { get; set; }
    }
}
