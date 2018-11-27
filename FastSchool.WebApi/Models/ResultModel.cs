using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastSchool.WebApi.Models
{
    public class ResultModel<T>
    {
        public ResultModel(int code, string msg, T result = default)
        {
            Code = code;
            Msg = msg;
            Result = result;
        }
        public int Code { get; set; }
        public string Msg { get; set; }
        public T Result { get; set; }
    }
}
