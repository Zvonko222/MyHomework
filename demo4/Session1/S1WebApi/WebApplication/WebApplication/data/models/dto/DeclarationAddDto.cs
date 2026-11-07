namespace WebApplication.data.models.dto
{
    public class DeclarationAddDto
    {
        public string id { get; set; }
        public string containerNumber { get; set; }
        public string hsCode { get; set; }
        public string countryOfOrigin { get; set; }
        public int tradeMode { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public int unitId { get; set; }
        public double cargoAmount { get; set; }
        public double dutyPayable { get; set; }
    }
}
