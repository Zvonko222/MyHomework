using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WebApplication.data.common;
using WebApplication.data.db;
using WebApplication.data.models.dto;

namespace WebApplication.Controllers.vehicle
{
    [RoutePrefix("api")]
    public class VehicleController : ApiController
    {
        [Route("vehicle"), HttpGet]
        public ApiResult GetVehicles(int userId)
        {
            using (var db = new S1DBEntities1())
            {
                var data = db.authorized_vehicle
                    .AsNoTracking()
                    .Where(x => x.authorized_cargo_owner == userId)
                    .Select(x => new
                    {
                        authorizedId = x.authorized_id,
                        licensePlateNumber = x.license_plate_number,
                        length = x.length,
                        width = x.width,
                        capacity = x.capacity,
                        startTime = x.authorization_start_time,
                        expiredTime = x.authorization_expired_time,
                        expired = x.authorization_expired_time < DateTime.Today
                    })
                    .OrderBy(x => x.expired)
                    .ThenBy(x => x.expiredTime)
                    .ToList()
                    .Select(x => new
                    {
                        authorizedId = x.authorizedId,
                        licensePlateNumber = x.licensePlateNumber,
                        length = x.length,
                        width = x.width,
                        capacity = x.capacity,
                        startTime = x.startTime.ToString("yyyy-MM-dd"),
                        expiredTime = x.expiredTime.ToString("yyyy-MM-dd"),
                        expired = x.expired
                    })
                    .ToList();

                return ApiUtils.ok(data, "Success");
            }
        }

        [Route("vehicle/add"), HttpPost]
        public ApiResult PostVehicle(VehicleAddDto dto)
        {
            if (dto == null)
            {
                return ApiUtils.fail(400, "Vehicle data is missing");
            }

            if (string.IsNullOrWhiteSpace(dto.licensePlateNumber))
            {
                return ApiUtils.fail(400, "License plate number is required");
            }

            if (dto.length < 1)
            {
                return ApiUtils.fail(400, "Length must be at least 1");
            }

            if (dto.width < 1)
            {
                return ApiUtils.fail(400, "Width must be at least 1");
            }

            if (dto.capacity < 1)
            {
                return ApiUtils.fail(400, "Capacity must be at least 1");
            }

            if (dto.authorizedCargoOwner <= 0)
            {
                return ApiUtils.fail(400, "The cargo owner is invalid");
            }

            DateTime startDate;
            if (!DateTime.TryParse(dto.authorizationStart, out startDate))
            {
                return ApiUtils.fail(400,
                    string.IsNullOrWhiteSpace(dto.authorizationStart)
                        ? "Start date is required"
                        : "Start date format is invalid");
            }

            DateTime expiredDate;
            if (!DateTime.TryParse(dto.authorizationExpired, out expiredDate))
            {
                return ApiUtils.fail(400,
                    string.IsNullOrWhiteSpace(dto.authorizationExpired)
                        ? "Expired date is required"
                        : "Expired date format is invalid");
            }

            if (startDate.Date <= DateTime.Today)
            {
                return ApiUtils.fail(400, "Start date must be later than today");
            }

            if (expiredDate < startDate)
            {
                return ApiUtils.fail(400, "Expired date cannot be earlier than start date");
            }

            using (var db = new S1DBEntities1())
            {
                if (!db.cargo_owner.Any(x => x.id == dto.authorizedCargoOwner))
                {
                    return ApiUtils.fail(400, "The cargo owner was not found");
                }

                if (db.authorized_vehicle.Any(x =>
                    x.license_plate_number == dto.licensePlateNumber &&
                    x.authorized_cargo_owner == dto.authorizedCargoOwner))
                {
                    return ApiUtils.fail(400, "The license plate number has been authorized");
                }

                var vehicle = new authorized_vehicle
                {
                    license_plate_number = dto.licensePlateNumber,
                    capacity = dto.capacity,
                    length = dto.length,
                    width = dto.width,
                    authorized_cargo_owner = dto.authorizedCargoOwner,
                    authorization_start_time = startDate,
                    authorization_expired_time = expiredDate
                };

                db.authorized_vehicle.Add(vehicle);
                db.SaveChanges();
                return ApiUtils.ok(vehicle.authorized_id, "Vehicle added successfully");
            }
        }

        [Route("vehicle/reauthorize"), HttpPost]
        public ApiResult PostReauthorize(ReauthorizeDto dto)
        {
            if (dto == null || dto.authorizedId <= 0)
            {
                return ApiUtils.fail(400, "Reauthorize data is invalid");
            }

            if (dto.authorizationExpired.Date <= DateTime.Today)
            {
                return ApiUtils.fail(400, "The new expired date must be after today");
            }

            

            using (var db = new S1DBEntities1())
            {
                var vehicle = db.authorized_vehicle.Find(dto.authorizedId);
                if (vehicle == null)
                {
                    return ApiUtils.fail(404, "The vehicle was not found");
                }

                vehicle.authorization_expired_time = dto.authorizationExpired;
                db.SaveChanges();
                return ApiUtils.ok(dto.authorizedId, "Reauthorize successfully");
            }
        }

    }
}
