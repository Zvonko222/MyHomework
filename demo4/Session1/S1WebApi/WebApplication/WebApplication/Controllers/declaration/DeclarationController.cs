using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WebApplication.data.common;
using WebApplication.data.db;
using WebApplication.data.models.dto;

namespace WebApplication.Controllers.declaration
{
    [RoutePrefix("api")]
    public class DeclarationController : ApiController
    {
        [Route("declaration"),HttpGet]
        public ApiResult GetDeclarationData(int userId = 0)
        {
            using (var db = new S1DBEntities1())
            {
                var rows = db.declarations
                    .AsNoTracking()
                    .Where(x => userId <= 0 || x.container.cargo_owner_id == userId)
                    .Select(x => new
                    {
                        declarationId = x.id,
                        containerNumber = x.container_number,
                        cargoAmount = x.cargo_amount,
                        dutyPayable = x.duty_payable ?? 0,
                        status = x.declaration_status.status,
                        voyageNumber = x.container.voyage_number
                    })
                    .ToList();

                var ids = rows.Select(x => x.declarationId).ToList();

                var reasons = db.declaration_status_change
                    .AsNoTracking()
                    .Where(x => ids.Contains(x.declaration_id) && x.reason != null)
                    .Select(x => new { x.declaration_id, x.reason, x.change_time })
                    .ToList()
                    .GroupBy(x => x.declaration_id)
                    .ToDictionary(
                        g => g.Key,
                        g => g.OrderByDescending(x => x.change_time)
                              .Select(x => x.reason)
                              .First());

                var data = rows.Select(x => new DeclarationDto
                    {
                        declarationId = x.declarationId,
                        containerNumber = x.containerNumber,
                        cargoAmount = Convert.ToDouble(x.cargoAmount),
                        dutyPayable = Convert.ToDouble(x.dutyPayable),
                        status = x.status,
                        voyageNumber = x.voyageNumber,
                        reason = reasons.ContainsKey(x.declarationId)
                            ? reasons[x.declarationId]
                            : null
                    })
                    .ToList();

                return ApiUtils.ok(data, "Success");
            }
        }

        [Route("declaration/voyage/{voyageNumber}"), HttpGet]
        public ApiResult GetVoyageArrival(string voyageNumber)
        {
            using (var db = new S1DBEntities1())
            {
                var voyage = db.voyages
                    .AsNoTracking()
                    .Where(x => x.voyage_number == voyageNumber)
                    .Select(x => new
                    {
                        x.actual_arrival_time,
                        x.estimated_arrival_time,
                        status = x.voyage_status.status
                    })
                    .FirstOrDefault();
                if (voyage == null)
                {
                    return ApiUtils.fail(404, "The voyage was not found");
                }

                bool isArrived = voyage.actual_arrival_time != null;
                DateTime? changedTime = null;
                if (!isArrived)
                {
                    changedTime = db.voyage_arrival_time_change
                        .AsNoTracking()
                        .Where(x => x.voyage_number == voyageNumber)
                        .OrderByDescending(x => x.change_time)
                        .Select(x => (DateTime?)x.estimated_arrival_time)
                        .FirstOrDefault();
                }
                DateTime arrivalTime = voyage.actual_arrival_time
                    ?? changedTime
                    ?? voyage.estimated_arrival_time;

                var data = new
                {
                    status = voyage.status,
                    arrivalTime = arrivalTime.ToString("yyyy-MM-dd"),
                    isArrived = isArrived
                };
                return ApiUtils.ok(data, "Success");
            }
        }

        [Route("declaration/container"), HttpGet]
        public ApiResult GetContainerState(string voyageNumber, string containerNumber, int userId)
        {
            using (var db = new S1DBEntities1())
            {
                bool found = db.containers
                    .AsNoTracking()
                    .Any(x =>
                        x.container_number == containerNumber &&
                        x.voyage_number == voyageNumber &&
                        x.cargo_owner_id == userId);

                if (!found)
                {
                    return ApiUtils.fail(404, "The container was not found");
                }

                bool declared = db.declarations
                    .AsNoTracking()
                    .Any(x =>
                        x.container_number == containerNumber &&
                        x.declaration_status.status != "Rejected");
                if (declared)
                {
                    return ApiUtils.fail(400, "The container has been declared");
                }

                return ApiUtils.ok("ok", "The container has been found");
            }
        }

        [Route("declaration/add"), HttpPost]
        public ApiResult PostDeclaration(DeclarationAddDto dto)
        {
            if (dto == null
                || string.IsNullOrWhiteSpace(dto.id)
                || string.IsNullOrWhiteSpace(dto.containerNumber)
                || string.IsNullOrWhiteSpace(dto.hsCode)
                || string.IsNullOrWhiteSpace(dto.countryOfOrigin)
                || dto.tradeMode <= 0
                || string.IsNullOrWhiteSpace(dto.description)
                || dto.quantity < 1
                || dto.unitId <= 0
                || dto.cargoAmount < 1
                || dto.dutyPayable < 0)
            {
                return ApiUtils.fail(400, "Declaration data is invalid");
            }

            using (var db = new S1DBEntities1())
            {
                if (!db.containers.Any(x => x.container_number == dto.containerNumber)
                    || !db.harmonized_system.Any(x => x.hs_code == dto.hsCode)
                    || !db.countries.Any(x => x.country_code == dto.countryOfOrigin)
                    || !db.trade_mode.Any(x => x.id == dto.tradeMode)
                    || !db.units.Any(x => x.id == dto.unitId))
                {
                    return ApiUtils.fail(400, "Declaration data is invalid");
                }

                if (db.declarations.Any(x => x.id == dto.id))
                {
                    return ApiUtils.fail(400, "The declaration id already exists");
                }

                if (db.declarations.Any(x =>
                    x.container_number == dto.containerNumber &&
                    x.declaration_status.status != "Rejected"))
                {
                    return ApiUtils.fail(400, "The container has been declared");
                }

                var pending = db.declaration_status.FirstOrDefault(x => x.status == "Pending");
                if (pending == null)
                {
                    return ApiUtils.fail(500, "Pending status was not found");
                }

                var entity = new WebApplication.data.db.declaration
                {
                    id = dto.id,
                    declaration_status_id = pending.id,
                    container_number = dto.containerNumber,
                    hs_code = dto.hsCode,
                    country_of_origin = dto.countryOfOrigin,
                    trade_mode = dto.tradeMode,
                    description = dto.description,
                    quantity = dto.quantity,
                    unit_id = dto.unitId,
                    cargo_amount = Convert.ToDecimal(dto.cargoAmount),
                    duty_payable = Convert.ToDecimal(dto.dutyPayable),
                    declaration_time = DateTime.Now
                };

                db.declarations.Add(entity);
                db.SaveChanges();
                return ApiUtils.ok(dto.id, "Declaration submitted successfully");
            }
        }
    }
}
