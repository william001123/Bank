using MongoDB.Driver;

namespace Bank.Repositories
{
    public class MongoDBRepository
    {

        public MongoClient Client { get; set; }
        public IMongoDatabase db { get; set; }


        public MongoDBRepository() 
        {
        
            Client = new MongoClient("mongodb://127.0.0.1:27017");
            db = Client.GetDatabase("Bank");
        } 
    }
}
