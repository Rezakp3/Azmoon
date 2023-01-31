using System.ComponentModel.DataAnnotations;

namespace TravelService.Model
{
    public class Travel
    {
        [Key]
        public int Id { get; init; }
        public DateTime TDate { get; private set; }
        public int Start { get; private set; }
        public int End { get; private set; }
        public int Distance { get; private set; }
        [MaxLength(10)]
        public string? OfferCode { get; private set; }
        public State TState { get; private set; }

        #region Relations
        public Guid TravelCode { get; private set; }

        public Guid DriverId { get; private set; }

        
        public Guid TravelerId { get; set; }
        public Traveler Traveler { get; set; }

        #endregion

        public Travel(int start, int end, int distance, Guid driverId, string? offerCode, State tState, Guid travelCode, Guid travelerId)
        {
            TDate = DateTime.Now;
            Start = start;
            End = end;
            Distance = distance;
            DriverId = driverId;
            OfferCode = offerCode;
            TState = tState;
            TravelCode = travelCode;
            TravelerId = travelerId;
        }
        public void SetState(State state) => TState = state;
    }
    public enum State
    {
        Start,
        End,
        Cancel,
        Unknown
    }
}
