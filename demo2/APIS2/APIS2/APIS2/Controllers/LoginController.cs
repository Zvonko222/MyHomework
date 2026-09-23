using APIS2.Common;
using APIS2.Models;
using APIS2.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIS2.Controllers
{
    [RoutePrefix("api")]
    public class LoginController : ApiController
    {
        [Route("login"),HttpPost]
        public ApiResult<object> PostLogin(LoginDto dto)
        {
            using(var db = new Session2Entities())
            {
                var data = db.Staffs
                    .Where(x => x.StaffId == dto.staffId && x.Password == dto.password)
                    .FirstOrDefault();
                if(data == null)
                {
                    return ApiResult<object>.fail(404, "dose not found");
                }
                return ApiResult<object>.success(dto.staffId, "Login Success");

            }
        }
    }
}
