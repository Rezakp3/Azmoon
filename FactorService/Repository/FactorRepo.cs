using FactorService.Contract;
using FactorService.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FactorService.Repository
{
    public class FactorRepo : IFactorRepo
    {
        private readonly IMongoCollection<Factor> db;

        public FactorRepo(IOptions<FactorDbSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(options.Value.DatabaseName);
            db = mongoDb.GetCollection<Factor>(options.Value.FactorsCollectionName);
        }

        public (int, int) CalculatePrice(int start, int end)
            => (GenerateRandomNumber(6, 15), GenerateRandomNumber(10000, 80000));

        public bool Create(Factor factor)
        {
            try
            {
                db.InsertOne(factor);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Factor FindBy(string id)
            => db.Find(x => x.Id == id).FirstOrDefault();

        private int GenerateRandomNumber(int first, int second)
        {
            Random random = new Random();
            return random.Next(first, second);
        }

        public List<Factor> GetAll()
            => db.Find(_ => true).ToList();

        public int GetOffer(string offer)
            => GenerateRandomNumber(2000, 6000);

        public bool Remove(string id)
        {
            try
            {
                db.DeleteOne(x => x.Id == id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Factor factor)
        {
            try
            {
                db.ReplaceOne(x => x.Id == factor.Id, factor);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
