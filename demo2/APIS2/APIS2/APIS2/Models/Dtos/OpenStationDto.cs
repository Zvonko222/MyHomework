using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIS2.Models.Dtos
{
    public class OpenStationDto
    {
        public int numberOfPeople { get; set; }
        public bool hasVase { get; set; }
        public int stationId { get; set; }
    }
}