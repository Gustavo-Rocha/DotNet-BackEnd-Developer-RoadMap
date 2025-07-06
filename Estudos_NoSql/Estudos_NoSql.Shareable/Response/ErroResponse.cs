using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_NoSql.Shareable.Response
{
    public class ErroResponse : Exception
    {
        public ErroResponse(string message) : base()
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
