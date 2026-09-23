using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Session3.Tools
{
    public class ApiResult<T>
    {
        public string msg { get; set; }
        public T data { get; set; }
        public int code { get; set; }
        public static ApiResult<T> success(T data, string msg)
        {
            return new ApiResult<T> { code = 200, msg = msg, data = data };
        }
        public static ApiResult<T> fail(T data, string msg,int code)
        {
            return new ApiResult<T> { code = code, msg = msg, data = data };
        }

    }
}