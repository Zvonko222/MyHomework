using Session3.Models;
using Session3.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Session3.Controllers
{
    [RoutePrefix("api")]
    public class LoginController : ApiController
    {
        // Post: Login
        [Route("login")]
        [HttpPost]
        public ApiResult<object> login(UserDto user)
        {
            using(var db = new WorldSkillsBookingEntities())
            {
                var data = db.Users
                    .Where(u => u.Username == user.username)
                    .Select(u => new
                    {
                        userId = u.ID,
                        password = u.Password
                    })
                    .FirstOrDefault();
                if(data == null)
                {
                    return ApiResult<object>.fail(null, "this username doesnt exist", 404);
                }
                if(data.password == user.password)
                {
                    return ApiResult<object>.success(data.userId, "Login Success");
                }
                else
                {
                    return ApiResult<object>.fail(null, "Password is mistake", 401);

                }

            }
        }
    }
}