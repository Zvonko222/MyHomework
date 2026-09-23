using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIS2.Models.Dtos
{
    public class LoginDto
    {
        public string staffId { get; set; }
        public string password { get; set; }
    }
}