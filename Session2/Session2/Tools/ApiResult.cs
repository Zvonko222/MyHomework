using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2.Tools
{
    internal class ApiResult<T>
    {
        public int code { get; set; }
        public string msg { get; set; }
        public T data { get; set; }
        public static ApiResult<T> success(T data, int code, string msg)
        {
            return new ApiResult<T> { data = data, code = code, msg = msg };
        }
        public static ApiResult<T> fail(int code, string msg)
        {
            return new ApiResult<T> { data = default(T), code = code, msg = msg };
        }
    }
}
