namespace WebApplication.data.models.dto
{
    public class VehicleAddDto
    {
        public string licensePlateNumber { get; set; }
        public int length { get; set; }
        public int width { get; set; }
        public int capacity { get; set; }
        public int authorizedCargoOwner { get; set; }
        public string authorizationStart { get; set; }
        public string authorizationExpired { get; set; }
    }
}
