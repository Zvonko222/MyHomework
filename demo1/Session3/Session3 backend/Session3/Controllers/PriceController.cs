using Session3.Models;
using Session3.Models.Dtos;
using Session3.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Session3.Controllers
{
    [RoutePrefix("api")]
    public class PriceController : ApiController
    {
        // GET: Price
        [Route("price"), HttpPost]
        public ApiResult<object> PostPrice(PriceDto priceDto)
        {
            int userId = priceDto.userId;
            int itemId = priceDto.itemId;

            using (var db = new BookingEntities())
            {
                var data = db.BookingDetails
                    .Where(bd =>
                    bd.Booking.User.ID == userId &&
                    bd.ItemPrice.Item.ID == itemId)
                    .Select(bd => new
                    {
                        bookingDate = bd.Booking.BookingDate,
                        amountPaid = bd.Booking.AmountPaid,
                        hostRules = bd.ItemPrice.Item.HostRules,
                        isRefund = bd.IsRefund,
                        refundDate = bd.RefundDate
                    })
                    .ToList();
                if (!data.Any())
                {
                    return ApiResult<object>.fail(null,"data does not exist",404);
                }
                return ApiResult<object>.success(data, "success");
            }

        }
    }
}