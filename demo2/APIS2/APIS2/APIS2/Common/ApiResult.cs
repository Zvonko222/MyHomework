using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIS2.Common
{
    public class ApiResult<T>   
    {
        public int code { get; set; }
        public T data { get; set; }
        public string msg { get; set; }
        public static ApiResult<T> success(T data,string msg)
        {
            return new ApiResult<T> { code = 200, data = data, msg = msg };
        }
        public  static ApiResult<T> fail(int code,string msg)
        {
            return new ApiResult<T> { code = code, data = default(T), msg = msg };
        }

    }
}