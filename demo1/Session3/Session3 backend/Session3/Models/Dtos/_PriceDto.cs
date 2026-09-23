using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Session3.Models.Dtos
{
    public class _PriceDto
    {
        public string bookingDate { get; set; }
        public double amountPaid { get; set; }
        public string hostRules { get; set; }
        public bool isRefund { get; set; }
        public string refundDate { get; set; }

    }
}