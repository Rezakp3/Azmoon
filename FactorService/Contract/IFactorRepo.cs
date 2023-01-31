using FactorService.Model;

namespace FactorService.Contract
{
    public interface IFactorRepo
    {
        public bool Create(Factor factor);
        public bool Update(Factor factor);
        public bool Remove(string id);
        public Factor FindBy(string id);
        public List<Factor> GetAll();
        public (int distance, int price) CalculatePrice(int start, int end);
        public int GetOffer(string offer);
    }
}
