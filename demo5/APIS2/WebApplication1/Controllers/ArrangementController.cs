using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Common;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api")]
    public class ArrangementController : ApiController
    {
        [Route("arrangement"),HttpGet]
        public ApiResult<object> GetArrangement()
        {
            using(var db = new Session2Entities())
            {
                //var checkoutData = db.OrderFlowers
                //    .Where(o => o.OpenStation.IsCheckout == true)
                //    .Select(o => new
                //    {
                //        stationId = o.OpenStation.Id,
                //        openTime = o.OpenStation.OpenTime,
                //        checkoutTime = o.OpenStation.CheckOutTime,
                //        totalAmount = o.OpenStation.TotalAmount,
                //        isCheckout = o.OpenStation.IsCheckout
                //    })
                //    .OrderByDescending(o => o.checkoutTime);

                //using (var db = new Session2Entities())
                //{
                //    var dbPassword = db.Staffs
                //        .Where(s => s.StaffId == dto.staffId)
                //        .Select(s => s.Password)
                //        .FirstOrDefault();
                //    if (dbPassword == null)
                //    {
                //        return ApiResult<object>.fail(404, "用户不存在");
                //    }
                //    if (dbPassword != dto.password)
                //    {
                //        return ApiResult<object>.fail(500, "密码错误");
                //    }
                //    return ApiResult<object>.success(dto.staffId, "登入成功");

                var data = db.OpenStations
                .Select(o => new
                {
                    stationId = o.StationId,
                    openTime = o.OpenTime,
                    checkoutTime = o.CheckOutTime,
                    totalAmount = o.TotalAmount,
                    isCheckout = o.IsCheckout
                })
                .ToList();

                if(data.Count == 0)
                {
                    return ApiResult<object>.fail(404, "doesnt exist");
                }
                return ApiResult<object>.success(data, "Query success");

            }
        }

    }
}
