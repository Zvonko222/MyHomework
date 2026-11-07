using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Common;
using WebApplication1.Models;
using WebApplication1.Models.Dtos;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api")]
    public class LoginController : ApiController
    {
        [Route("login"),HttpPost]
        public ApiResult<Object> PostLogin(LoginDto dto)
        {
            using(var db = new Session2Entities())
            {
                var dbPassword = db.Staffs
                    .Where(s => s.StaffId == dto.staffId)
                    .Select(s => s.Password)
                    .FirstOrDefault();
                if(dbPassword == null)
                {
                    return ApiResult<object>.fail(404, "用户不存在");
                }
                if(dbPassword != dto.password)
                {
                    return ApiResult<object>.fail(500, "密码错误");
                }
                return ApiResult<object>.success(dto.staffId, "登入成功");
               
            }
        }
    }
}
