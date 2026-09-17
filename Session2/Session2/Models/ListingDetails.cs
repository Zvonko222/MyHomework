using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2.Models
{
    internal class ListingDetails
    {
        public string type { get; set; }
        public string title { get; set; }
        public int capacity { get; set; }
        public int numberOfBeds { get; set; }
        public int numberOfBedrooms { get; set; }
        public int numberOfBathrooms { get; set; }
        public string approximateAddress { get; set; }
        public string exactAdress { get; set; }
        public string desciption { get; set; }
        public string  hostRules { get; set; }
        public int minimum { get; set; }
        public int maximum { get; set; }
    }
}
