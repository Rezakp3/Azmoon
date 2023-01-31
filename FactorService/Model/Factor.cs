using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FactorService.Model
{
    public class Factor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; init; }
        public DateTime FTime { get; init; }
        public Guid TravelerId { get; private set; }
        public Guid DriverId { get; private set; }
        public int Price { get; private set; }
        public int Offer { get; private set; }
        public int FinalPrice { get; private set; }

        public Guid TravelCode { get; private set; }

        public Factor(Guid travelerId, Guid driverId, int price, int offer)
        {
            FTime = DateTime.Now;
            TravelerId = travelerId;
            DriverId = driverId;
            Price = price;
            Offer = offer;
            FinalPrice = price - offer;
            TravelCode = Guid.NewGuid();
        }
        public void Update(Guid driverId, int price, int offer)
        {
            DriverId = driverId;
            Price = price;
            Offer = offer;
            FinalPrice = price - offer;
        }
    }
}
