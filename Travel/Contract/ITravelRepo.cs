using TravelService.Model;

namespace TravelService.Contract
{
    public interface ITravelRepo
    {
        public bool Create(Travel T);
        public bool StartTravel(int id);
        public bool EndTravel(int id);
        public bool CancelTravel(int id);
        public bool ChangeState(State s, int id);
        public Travel FindBy(int id);
        public Guid GetDriverId(int id);
    }
}
