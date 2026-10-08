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
    public class StationController : ApiController
    {
        [Route("station/flower"),HttpGet]
        public ApiResult<object> GetFlower()
        {
            using(var db = new Session2Entities())
            {
                var data = db.OrderFlowers
                    .Select(x => new
                    {
                        flowerId = x.FlowerId,
                        orderNumber = x.Number,
                        price = x.Flower.Price,
                        stock = x.Flower.InventoryNumber,
                        name = x.Flower.Name,
                        category = x.Flower.FlowerCategory.Name,
                        categoryId = x.Flower.CategoryId
                    }).ToList();
                if(data.Count == 0)
                {
                    return ApiResult<object>.fail(404, "Flower not found");
                }
                return ApiResult<object>.success(data, "Flower found success");
            }
        }

        [Route("station/checkout"), HttpPost]
        public ApiResult<object> PostCheckOut(int stationId)
        {
            using (var db = new Session2Entities())
            {
                var data = db.OpenStations
                    .Where(x => x.StationId == stationId &&
                    x.IsCheckout == false)
                    .FirstOrDefault();
                if (data == null)
                {
                    return ApiResult<object>.fail(404, "station not found");
                }
                data.IsCheckout = true;
                data.CheckOutTime = DateTime.Now;
                db.SaveChanges();
                return ApiResult<object>.success(null, "Check out successfully");
            }
        }
        [Route("station/open"), HttpPost]
        public ApiResult<object> PostOpenStation(OpenStationDto dto)
        {
            using (var db = new Session2Entities())
            {
                var dbMaximumPeople = db.OpenStations
                    .Where(x => x.Id == dto.stationId)
                    .Select(x => x.ArrangementStation.MaximumPeople)
                    .FirstOrDefault();

                if (dbMaximumPeople == null)
                {
                    return ApiResult<object>.fail(500, "database error");
                }
                if (dto.numberOfPeople > dbMaximumPeople)
                {
                    return ApiResult<object>.fail(400, "Number of people exceeds maximum capacity");
                }

                var openStation = new OpenStation
                {
                    StationId = dto.stationId,
                    NumberOfPeople = dto.numberOfPeople,
                    HasVase = dto.hasVase,
                    OpenTime = DateTime.Now,
                    IsCheckout = false,
                    CheckOutTime = null,
                    TotalAmount = 0
                };
                db.OpenStations.Add(openStation);
                db.SaveChanges();
                return ApiResult<object>.success(null, "Station opened successfully");
            }
        }
        [Route("station"), HttpGet]
        public ApiResult<object> GetStation()
        {
            using (var db = new Session2Entities())
            {


                var data = db.OpenStations
                    .Where(x => x.IsCheckout == false)
                    .OrderBy(x => x.OpenTime)
                    .Select(x => new
                    {
                        stationId = x.StationId,
                        maximumPeople = x.ArrangementStation.MaximumPeople,
                        isEnable = x.ArrangementStation.IsEnable,
                        isCheckout = x.IsCheckout,

                    })
                    .ToList();
                var checkoutData = db.OpenStations
                    .Where(x => x.IsCheckout == true)
                    .OrderBy(x => x.OpenTime)
                    .Select(x => new
                    {
                        stationId = x.StationId,
                        maximumPeople = x.ArrangementStation.MaximumPeople,
                        isEnable = x.ArrangementStation.IsEnable,
                        isCheckout = x.IsCheckout,

                    })
                    .ToList();
                data.AddRange(checkoutData);

                if (data.Count == 0)
                {
                    return ApiResult<object>.fail(404, "Data does not found");
                }
                return ApiResult<object>.success(data, "success");
            }
        }
    }
}
