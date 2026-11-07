using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WebApplication.data.common;
using WebApplication.data.db;
using WebApplication.data.models.dto;

namespace WebApplication.Controllers.login
{
    [RoutePrefix("api")]
    public class loginController : ApiController
    {
        [HttpGet,Route("test/array")]
        public ApiResult TestArray()
        {
            List<DeclarationDto> list = new List<DeclarationDto>();
            list.Add(new DeclarationDto
            {
                cargoAmount = 1,
                containerNumber = "2"
            });
            return ApiUtils.ok(list, "success");
        }
        [HttpGet,Route("test")]
        public ApiResult Test()
        {
            return ApiUtils.ok("success", "success");
        }

   
        [HttpPost, Route("login")]
        public ApiResult PostLogin(LoginDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.username) || string.IsNullOrWhiteSpace(dto.password))
            {
                return ApiUtils.fail(400, "Username and password are required");
            }

            using (var db = new S1DBEntities1())
            {
                int ownerId = db.cargo_owner
                    .AsNoTracking()
                    .Where(x =>
                        x.username == dto.username &&
                        x.password == dto.password)
                    .Select(x => x.id)
                    .FirstOrDefault();

                if (ownerId == 0)
                {
                    return ApiUtils.fail(400, "Username or password is incorrect");
                }
                return ApiUtils.ok(ownerId, "success");
            }
        }
    }
}
