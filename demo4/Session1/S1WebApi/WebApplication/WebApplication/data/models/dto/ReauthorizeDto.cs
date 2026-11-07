using System;

namespace WebApplication.data.models.dto
{
    public class ReauthorizeDto
    {
        public int authorizedId { get; set; }
        public DateTime authorizationExpired { get; set; }
    }
}
