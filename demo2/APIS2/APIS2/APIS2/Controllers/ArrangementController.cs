using APIS2.Common;
using APIS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIS2.Controllers
{
    [RoutePrefix("api/home")]
    public class ArrangementController : ApiController
    {
        [Route("arrangement"),HttpGet]
        public ApiResult<object> GetArrangementList()
        {
            //工作台编号、开始时间、结账时间、总金额。未结账的工作台显示在上方，按开始时间升序排列；已结账的
            //工作台显示在下方，按结账时间降序排列。

            using (var db = new Session2Entities())
            {
                var data = db.OpenStations
                    .Where(x => x.IsCheckout == false)
                    .OrderBy(x => x.OpenTime)
                    .Select(x => new
                    {
                        stationId = x.StationId,
                        openTime = x.OpenTime,
                        checkoutTime = x.CheckOutTime,
                        totalAmount = x.TotalAmount
                    })
                    .ToList()
                    .Select(x => new
                    {
                        stationId = x.stationId,
                        openTime = x.openTime.ToString("yyyy-MM-dd"),
                        checkoutTime = x.checkoutTime.HasValue? x.checkoutTime.Value.ToString("yyyy-MM-dd"):null,
                        totalAmount = x.totalAmount
                    })
                    .ToList();

                var checkoutData = db.OpenStations
                    .Where(x => x.IsCheckout == true)
                    .OrderByDescending(x => x.OpenTime)
                    .Select(x => new
                    {
                        stationId = x.StationId,
                        openTime = x.OpenTime,
                        checkoutTime = x.CheckOutTime,
                        totalAmount = x.TotalAmount
                    })
                    .ToList()
                    .Select(x => new
                    {
                        stationId = x.stationId,
                        openTime = x.openTime.ToString("yyyy-MM-dd"),
                        checkoutTime = x.checkoutTime.HasValue ? x.checkoutTime.Value.ToString("yyyy-MM-dd") : null,
                        totalAmount = x.totalAmount
                    })
                    .ToList();

                data.AddRange(checkoutData);
                if(data.Count == 0)
                {
                    return ApiResult<object>.fail(404, "data does not found");
                }
                return ApiResult<object>.success(data, "Query Success");
            }
            
        }
    }
}
