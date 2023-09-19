using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Db.dto
{
    public class Response
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public object Data { get; set; }
    }

    public sealed class ExceptionResponse : Response
    {
        public string Message { get; set; }
    }
}
