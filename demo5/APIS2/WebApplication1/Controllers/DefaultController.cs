using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api")]
    public class DefaultController : ApiController
    {
        [Route("test"),HttpGet]
        public IHttpActionResult GetTest()
        {
            return Ok("TEST");
        }
    }
}
