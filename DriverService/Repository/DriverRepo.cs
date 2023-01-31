using DriverService.Contract;
using DriverService.Model;

namespace DriverService.Repository
{
    public class DriverRepo : IDriverRepo
    {
        private readonly DriverDbContext db;

        public DriverRepo(DriverDbContext db)
        {
            this.db = db;
        }

        public bool Active(Guid id)
            => ChangeActiveState(id, true);

        public bool ApplyUpdate(Driver driver)
        {
            db.Update(driver);
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool ChangeActiveState(Guid id, bool state)
        {
            var driver = FindBy(id);
            driver.SetActiveState(state);
            return ApplyUpdate(driver);
        }

        public int? AddScore(Guid id, int score)
        {
            var driver = FindBy(id);
            driver.ChangeScore(score);
            return ApplyUpdate(driver) ? driver.Score : null;
        }

        public bool Create(Driver driver)
        {
            db.Add(driver);
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool Deactive(Guid id)
            => ChangeActiveState(id, false);

        public Driver FindBy(Guid id)
            => db.Drivers.Find(id);

        public IEnumerable<Driver> GetAll()
            => db.Drivers.ToList();

        public bool Remove(Guid id)
        {
            var driver = FindBy(id);
            db.Remove(driver);

            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool Update(Guid id, Driver dr)
        {
            var driver = FindBy(id);
            driver.Update(dr.Name, dr.Family, dr.Number, dr.CarBrand, dr.CarModel, dr.CarTag, dr.NationalCode);
            return ApplyUpdate(driver);
        }
    }
}
