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
        [Route("price"),HttpPost]
        public ApiResult<object> PostPrice(PriceDto priceDto)
        {
            int userId = priceDto.userId;
            int itemId = priceDto.itemId;

            string sql = $"" +
                $"select b.BookingDate,b.AmountPaid,i.HostRules,bd.isRefund,bd.RefundDate " +
                $"from Users u " +
                $"join Items i " +
                $"on u.ID=i.UserID " +
                $"join Bookings b " +
                $"on b.UserID=u.ID " +
                $"join BookingDetails bd " +
                $"on bd.BookingID=b.ID " +
                $"join ItemPrices ip on ip.ID=bd.ItemPriceID " +
                $"where u.ID={userId} " +
                $"and i.ID={itemId} ";

            DataTable table = DBHelper.executeQuery(sql);
            if (table.Rows.Count<=0)
            {
                return ApiResult<object>.fail(null, "doesnt have a detail", 500);
            }
            List<_PriceDto> _PriceDtos = new List<_PriceDto>();
            
            foreach(DataRow row in table.Rows)
            {
                _PriceDto _PriceDto = new _PriceDto();

                _PriceDto.amountPaid = Convert.ToDouble(row["AmountPaid"].ToString());
                _PriceDto.bookingDate = Convert.ToString(row["BookingDate"].ToString());
                _PriceDto.isRefund = Convert.ToBoolean(row["isRefund"].ToString());
                _PriceDto.hostRules = row["HostRules"].ToString();
                _PriceDto.refundDate = row["RefundDate"].ToString();

                _PriceDtos.Add(_PriceDto);

            }
            return ApiResult<object>.success(_PriceDtos, "success");
        }
    }
}