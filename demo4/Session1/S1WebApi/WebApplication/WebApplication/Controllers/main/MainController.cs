using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WebApplication.data.common;
using WebApplication.data.db;

namespace WebApplication.Controllers.main
{
    [RoutePrefix("api")]
    public class MainController : ApiController
    {
        [Route("voyage/departure"),HttpGet]
        public ApiResult GetDepartureCountryAndPort()
        {
            using (var db = new S1DBEntities1())
            {
                var data = db.ports
                    .AsNoTracking()
                    .Select(x => new
                    {
                        portName = x.name,
                        countryName = x.country.name
                    })
                    .ToList()
                    .GroupBy(x => x.countryName)
                    .OrderBy(g => g.Key)
                    .Select(g => new
                    {
                        countryName = g.Key,
                        ports = g
                        .OrderBy(x => x.portName)
                        .Select(x => x.portName)
                        .ToList()
                    })
                    .ToList();
                return ApiUtils.ok(data, "Success");
            }
        }

        [Route("voyage"), HttpGet]
        public ApiResult GetVoyages()
        {
            using (var db = new S1DBEntities1())
            {
                var rows = db.voyages
                    .AsNoTracking()
                    .Select(x => new
                    {
                        x.actual_arrival_time,
                        departurePortName = x.port.name,
                        x.departure_time,
                        destinationPortName = x.port1.name,
                        x.estimated_arrival_time,
                        status = x.voyage_status.status,
                        x.voyage_number,
                        departureCountryName = x.port.country.name,
                        destinationCountryName = x.port1.country.name
                    })
                    .ToList();

                var voyageNumbers = rows
                    .Where(x => x.actual_arrival_time == null)
                    .Select(x => x.voyage_number)
                    .ToList();

                var changes = db.voyage_arrival_time_change
                    .AsNoTracking()
                    .Where(x => voyageNumbers.Contains(x.voyage_number))
                    .Select(x => new
                    {
                        x.voyage_number,
                        x.estimated_arrival_time,
                        x.change_time
                    })
                    .ToList()
                    .GroupBy(x => x.voyage_number)
                    .ToDictionary(
                        g => g.Key,
                        g => g.OrderByDescending(x => x.change_time)
                              .Select(x => x.estimated_arrival_time)
                              .First());

                var data = rows
                    .Select(x => new
                    {
                        actualArrivalTime = x.actual_arrival_time?.ToString("yyyy-MM-dd"),
                        departurePortName = x.departurePortName,
                        departureTime = x.departure_time.ToString("yyyy-MM-dd"),
                        destinationPortName = x.destinationPortName,
                        estimatedArrivalTime = x.estimated_arrival_time.ToString("yyyy-MM-dd"),
                        newEstimatedArrivalTime = x.actual_arrival_time == null &&
                                                  changes.ContainsKey(x.voyage_number)
                            ? changes[x.voyage_number].ToString("yyyy-MM-dd")
                            : null,
                        status = x.status,
                        voyageNumber = x.voyage_number,
                        departureCountryName = x.departureCountryName,
                        destinationCountryName = x.destinationCountryName
                    })
                    .ToList();
                return ApiUtils.ok(data, "Success");
            }
        }
    }
}
