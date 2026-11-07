using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Common
{
    public class ApiResult<T>
    {
        public T data { get; set; }
        public int code { get; set; }
        public string msg { get; set; }
        public static ApiResult<T> success(T data,string msg)
        {
            return  new ApiResult<T> { data = data, code = 200,msg = msg };
        }
        public static ApiResult<T> fail(int code,string msg)
        {
            return new ApiResult<T> { code = code, msg = msg };
        }
    }
}