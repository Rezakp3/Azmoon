using TravelService.Contract;
using TravelService.Model;

namespace TravelService.Repository
{
    public class TravelerRepo : ITravelerRepo
    {
        private readonly TravelDbContext db;

        public TravelerRepo(TravelDbContext db)
        {
            this.db = db;
        }

        public bool Create(Traveler tr)
        {
            db.Travelers.Add(tr);
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool Remove(Guid id)
        {
            var traveler = FindBy(id);
            db.Remove(traveler);
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public Traveler FindBy(Guid id)
            => db.Travelers.Find(id);

        public IEnumerable<Traveler> GetAll()
            => db.Travelers.ToList();

        public bool Update(Guid id, Traveler tr)
        {
            var traveler = FindBy(id);
            traveler.Update(tr.Name, tr.Family, tr.NationalCode, tr.Number);
            db.Update(traveler);
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
