using TravelService.Contract;
using TravelService.Model;

namespace TravelService.Repository
{
    public class TravelRepo : ITravelRepo
    {
        private readonly TravelDbContext db;

        public TravelRepo(TravelDbContext dbContext)
        {
            db = dbContext;
        }

        public bool CancelTravel(int id)
            => ChangeState(State.Cancel, id);

        public bool ChangeState(State state, int id)
        {
            var travel = FindBy(id);
            travel.SetState(state);
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool Create(Travel T)
        {
            var entity = db.Travels.Add(T);
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool EndTravel(int id)
            => ChangeState(State.End, id);

        public Travel FindBy(int id)
            => db.Travels.Find(id);

        public Guid GetDriverId(int id)
            => db.Travels.Find(id).DriverId;

        public bool StartTravel(int id)
            => ChangeState(State.Start, id);
    }
}
