namespace WebApplication.data.common
{
    public class ApiResult
    {
        public object data { get; set; }
        public int code { get; set; }
        public string msg { get; set; }
    }

    public static class ApiUtils
    {
        public static ApiResult ok(object data, string msg)
        {
            return new ApiResult { data = data, msg = msg, code = 200 };
        }

        public static ApiResult fail(int code, string msg)
        {
            return new ApiResult { data = null, msg = msg, code = code };
        }
        
    }
}
