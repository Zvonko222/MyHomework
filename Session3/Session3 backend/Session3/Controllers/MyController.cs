using Session3.Models;
using Session3.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Session3.Controllers
{
    [RoutePrefix("api")]
    public class MyController : ApiController
    {


       
 

        [Route("test")]
        [HttpGet]
        public IHttpActionResult test()
        {
            string sql = "" +
                "select * " +
                "from Bookings ";
            DataTable table = DBHelper.executeQuery(sql);

            return Ok(table);
        }
    }
}