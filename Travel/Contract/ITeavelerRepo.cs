using TravelService.Model;

namespace TravelService.Contract
{
    public interface ITravelerRepo
    {
        public bool Create(Traveler tr);
        public bool Update(Guid id,Traveler tr);
        public bool Remove(Guid id);
        public Traveler FindBy(Guid id);   
        public IEnumerable<Traveler> GetAll();
    }
}
