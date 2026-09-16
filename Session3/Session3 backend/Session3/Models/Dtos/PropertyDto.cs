using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Session3.Models.Dtos
{
    public class PropertyDto
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public int minimumNights { get; set; }
        public int maximumNights { get; set; }
        public string date { get; set; }
        public bool isInnerFiveDay { get; set; }

    }
}