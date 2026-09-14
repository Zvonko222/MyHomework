using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Session3.Tools
{
    public class ApiResult<T>
    {
        public bool success { get; set; }
        public string msg { get; set; }
        public List<T> dataList { get; set; }
        public int code { get; set; }
        
    }
}