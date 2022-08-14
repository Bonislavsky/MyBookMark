using MyBookMarks.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.Domain.Response
{
    public class Response<T>
    {
        public string Description { get; set; }
        public T Data { get; set; }
        public StatusCode StatusCode { get; set; }
    }
}
