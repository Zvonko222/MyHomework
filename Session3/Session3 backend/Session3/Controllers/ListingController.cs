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
    public class ListingController : ApiController
    {
        [Route("property/test"), HttpGet]
        public ApiResult<object> test()
        {
            return ApiResult<object>.success("aaa", "test");
        }

        // Post: Listing
        [Route("property")]
        [HttpPost]
        public ApiResult<object> postPerproty(int userId)
        {
            using (var db = new WorldSkillsBookingEntities())
            {
                var data = db.Items
                    .Where(i => i.User.ID == userId)
                    .SelectMany(i => i.ItemPrices)
                    .Select(ip => new
                    {
                        itemId = ip.Item.ID,
                        date = ip.Date,
                        itemPriceId = ip.ID,
                        itemTitle = ip.Item.Title,
                        maximumNights = ip.Item.MaximumNights,
                        minimumNights = ip.Item.MinimumNights,
                        userId = userId,
                        isInnerFiveDay = (ip.Item.MaximumNights - ip.Item.MinimumNights) <= 5
                    })
                    .OrderBy(x => x.maximumNights)
                    .ToList();
                
                if(!data.Any())
                {
                    return ApiResult<object>.fail(null, "data does not exist", 404);
                }
                var result = data.Select(x => new
                {
                    x.itemId,
                    date = x.date.ToString("yyyy-MM-dd"),
                    x.itemPriceId,
                    x.itemTitle,
                    x.maximumNights,
                    x.minimumNights,
                    x.userId,
                    x.isInnerFiveDay,
                });
                return ApiResult<object>.success(result, "Query success");
            }
        }

        [Route("property/{itemPricesId}")]
        [HttpGet]
        public ApiResult<object> getPropertyData(int itemPricesId)
        {
            using(var db = new WorldSkillsBookingEntities())
            {
                var data = db.ItemPrices
                    .Where(ip => ip.ID == itemPricesId)
                    .SelectMany(ip => ip.BookingDetails)
                    .Select(bd => new
                    {
                        bookingDate = bd.Booking.BookingDate,
                        amoutPaid = bd.Booking.AmountPaid
                    })
                    .ToList();
                if (!data.Any())
                {
                    return ApiResult<object>.fail(null, "data does not exist", 404);
                }
                return ApiResult<object>.success(data, "Query success");
            }
         
        }

    }
}