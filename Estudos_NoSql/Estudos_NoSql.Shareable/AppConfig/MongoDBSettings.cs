using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_NoSql.Shareable.AppConfig
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; } = default!;

        public string DatabaseName { get; set; } = default!;

        public DatabaseSettings  DatabaseSettings { get; set; } = default!;
    }
}
