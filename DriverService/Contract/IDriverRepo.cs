using DriverService.Model;

namespace DriverService.Contract
{
    public interface IDriverRepo
    {
        public bool Create(Driver driver);
        public bool Update(Guid id, Driver driver);
        public bool Remove(Guid id);
        public IEnumerable<Driver> GetAll();
        public Driver FindBy(Guid id);
        public bool Active(Guid id);
        public bool Deactive(Guid id);
        public int? AddScore(Guid id, int score);
        public bool ChangeActiveState(Guid id, bool state);
        public bool ApplyUpdate(Driver driver);
    }
}
