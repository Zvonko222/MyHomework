using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WebApplication.data.common;
using WebApplication.data.db;

namespace WebApplication.Controllers.options
{
    [RoutePrefix("api")]
    public class OptionsController : ApiController
    {
        [Route("hscode"), HttpGet]
        public ApiResult GetHsCodes()
        {
            using (var db = new S1DBEntities1())
            {
                var data = db.harmonized_system
                    .AsNoTracking()
                    .OrderBy(x => x.hs_code)
                    .Select(x => new
                    {
                        hsCode = x.hs_code,
                        description = x.hs_description,
                        dutyRate = x.duty_rate
                    })
                    .ToList();

                return ApiUtils.ok(data, "Success");
            }
        }

        [Route("country"), HttpGet]
        public ApiResult GetCountries()
        {
            using (var db = new S1DBEntities1())
            {
                var data = db.countries
                    .AsNoTracking()
                    .OrderBy(x => x.name)
                    .Select(x => new
                    {
                        name = x.name,
                        countryCode = x.country_code,
                        dutyRate = x.duty_rate
                    })
                    .ToList();

                return ApiUtils.ok(data, "Success");
            }
        }

        [Route("tradeMode"), HttpGet]
        public ApiResult GetTradeModes()
        {
            using (var db = new S1DBEntities1())
            {
                var data = db.trade_mode
                    .AsNoTracking()
                    .OrderBy(x => x.id)
                    .Select(x => new
                    {
                        id = x.id,
                        name = x.name,
                        dutyRate = x.duty_rate
                    })
                    .ToList();

                return ApiUtils.ok(data, "Success");
            }
        }

        [Route("unit"), HttpGet]
        public ApiResult GetUnits()
        {
            using (var db = new S1DBEntities1())
            {
                var data = db.units
                    .AsNoTracking()
                    .OrderBy(x => x.id)
                    .Select(x => new
                    {
                        id = x.id,
                        name = x.name
                    })
                    .ToList();

                return ApiUtils.ok(data, "Success");
            }
        }
    }
}
