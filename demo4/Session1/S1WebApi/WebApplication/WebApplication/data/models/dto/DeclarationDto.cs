namespace WebApplication.data.models.dto
{
    public class DeclarationDto
    {
        public string declarationId { get; set; }
        public string containerNumber { get; set; }
        public double cargoAmount { get; set; }
        public double dutyPayable { get; set; }
        public string status { get; set; }
        public string voyageNumber { get; set; }
        public string reason { get; set; }
    }
}
