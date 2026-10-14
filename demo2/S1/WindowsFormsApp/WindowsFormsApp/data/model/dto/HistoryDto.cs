using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.data.model.dto
{
    internal class HistoryDto
    {
        public string orderNo { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime? deliveryDate { get; set; }
        public double totalAmount { get; set; }
        public string status { set; get; }
        public string storeName { set; get; }
        public string action { get; set; }
        public string detail { get; set; }
    }
}
