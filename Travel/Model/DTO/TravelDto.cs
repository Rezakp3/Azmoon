namespace TravelService.Model.DTO
{
    public class AddTravelDto
    {
        public int Start { get; set; }
        public int End { get; set; }
        public Guid TravelCode { get; set; }
        public string OfferCode { get; set; }
        public Guid DriverId { get; set; }
        public Guid TravelerId { get; set; }
    }
}
