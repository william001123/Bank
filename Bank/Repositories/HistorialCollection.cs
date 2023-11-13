using Bank.Models;
using Bank.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Bank.Repositories
{
    public class HistorialCollection : IHistorialCollection
    {

        internal MongoDBRepository _repository = new MongoDBRepository();

        private IMongoCollection<Historial> _collection;        

        public HistorialCollection()
        {
            _collection = _repository.db.GetCollection<Historial>("Historial");
        }

        public async Task Insert(Historial entidad)
        {
            await _collection.InsertOneAsync(entidad);
        }

        public async Task<List<Historial>> Get(string CuentaOrigen)
        {
            var documet = await _collection.FindAsync(new BsonDocument { { "CuentaOrigen", CuentaOrigen } }).Result.ToListAsync();
            return documet;
        }
    }
}
