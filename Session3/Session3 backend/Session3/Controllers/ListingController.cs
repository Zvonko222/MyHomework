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
        public ApiResult<List<PropertyDto>> postPerproty(int userId)
        {
            string sql = "" +
                "select ip.Date,i.Title,ip.ID,i.MaximumNights,i.MinimumNights " +
                "from Items i " +
                "join ItemPrices ip " +
                "on i.ItemTypeID=ip.ID " +
                "join Users u " +
                "on u.ID = i.UserID " +
                "where u.ID = " + userId +
                "order by i.MaximumNights";

            DataTable table = DBHelper.executeQuery(sql);
            List<PropertyDto> propertyDtos = new List<PropertyDto>();

            foreach (DataRow row in table.Rows)
            {
                PropertyDto propertyDto = new PropertyDto();  
                propertyDto.title = row["Title"].ToString();
                propertyDto.date = row["Date"].ToString();
                propertyDto.id = Convert.ToInt32(row["ID"]);
                propertyDto.minimumNights = Convert.ToInt32(row["MinimumNights"]);
                propertyDto.maximumNights = Convert.ToInt32(row["MaximumNights"]);
                propertyDto.userId = userId;
                
                // date verification
                DateTime date = DateTime.Parse(row["Date"].ToString());
                if (date.AddDays(5) >= DateTime.Now)
                {
                    propertyDto.isInnerFiveDay = false;
                }
                else
                {
                    propertyDto.isInnerFiveDay = true;
                }

                propertyDtos.Add(propertyDto);
            }
            return ApiResult<List<PropertyDto>>.success(propertyDtos, "Query success");

        }

        [Route("property/{itemPricesId}")]
        [HttpGet]
        public ApiResult<List<Book>> getPropertyData(int itemPricesId)
        {
            string sql = $"" +
                $"select b.BookingDate,b.AmountPaid " +
                $"from ItemPrices ip " +
                $"join BookingDetails bd " +
                $"on ip.ID = bd.ItemPriceID " +
                $"join Bookings b " +
                $"on b.ID = bd.BookingID " +
                $"where ip.ID={itemPricesId}";
            DataTable table = DBHelper.executeQuery(sql);
            List<Book> books = new List<Book>();

            if (table.Rows.Count <= 0)
            {
                return ApiResult<List<Book>>.fail(null, "book count is null", 602);
            }

            foreach (DataRow row in table.Rows)
            {
                Book book = new Book();
                book.date = row["BookingDate"].ToString();
                book.paid = row["AmountPaid"].ToString();
                books.Add(book);
            }
            return ApiResult<List<Book>>.success(books, "Query Success");
        }

    }
}