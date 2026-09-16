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
        public ApiResult<object> login(Users user)
        {
            string sql = $"" +
                $"select * " +
                $"from Users " +
                $"where Username = '{user.username}'";

            DataTable table = DBHelper.executeQuery(sql);
            if (table.Rows.Count == 0)
            {
                return ApiResult<object>.fail(null, "this username doesnt exist", 500);
            }
            DataRow row = table.Rows[0];
            if (user.password == row["password"].ToString())
            {
                string id = row["ID"].ToString();
                return ApiResult<object>.success(id, "Login Success");
            }
            else
            {
                return ApiResult<object>.fail(null, "password is mistake", 601);
            }

        }
    }
}