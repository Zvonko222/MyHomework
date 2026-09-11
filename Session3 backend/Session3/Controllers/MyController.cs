using Session3.Models;
using Session3.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Session3.Controllers
{
    [RoutePrefix("api")]
    public class MyController : ApiController
    {
        [Route("property/{itemPricesId}")]
        [HttpGet]
        public IHttpActionResult getPropertyData(int itemPricesId)
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
            
            foreach(DataRow row in table.Rows)
            {
                Book book = new Book();
                book.date = row["BookingDate"].ToString();
                book.paid = row["AmountPaid"].ToString();
                books.Add(book);
            }
            return Ok(books);
        }

        [Route("property")]
        [HttpGet]
        public IHttpActionResult getPerproty()
        {
            string sql = "" +
                "select Date,Title,ip.ID " +
                "from Items i " +
                "join ItemPrices ip " +
                "on i.ItemTypeID=ip.ID ";
            DataTable table = DBHelper.executeQuery(sql);
            List<Property> properties = new List<Property>();
            foreach(DataRow row in table.Rows)
            {
                Property property = new Property();
                property.title = row["Title"].ToString();
                property.date = row["Date"].ToString();
                property.id = row["ID"].ToString();
                properties.Add(property);
            }
            return Ok(properties);
        }

        [Route("login")]
        [HttpPost]
        public IHttpActionResult login(Users user)
        {
            string sql = $"" +
                $"select * " +
                $"from Users " +
                $"where Username = '{user.username}'";

            DataTable table = DBHelper.executeQuery(sql);
            if(table.Rows.Count == 0)
            {
                return Ok(new
                {
                    success = false,
                    message = "username or password error"
                });
            }
            DataRow row = table.Rows[0];
            if (user.password == row["password"].ToString())
            {
                return Ok(new
                {
                    success = true,
                    message = "login success",
                    uid = row["ID"].ToString()
                });
            }
            else
            {
                return Ok(new
                {
                    success = false,
                    message = "username or password error"
                });
            }

        }

        [Route("test")]
        [HttpGet]
        public IHttpActionResult test()
        {
            string sql = "" +
                "select * " +
                "from Bookings ";
            DataTable table = DBHelper.executeQuery(sql);

            return Ok(table);
        }
    }
}