using Bank.Models;
using Bank.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Bank.Repositories
{
    public class AutenticacionCollection : IAutenticacionCollection
    {

        internal MongoDBRepository _repository = new MongoDBRepository();

        private IMongoCollection<Cliente> _collection;

        public AutenticacionCollection()
        {
            _collection = _repository.db.GetCollection<Cliente>("Cliente");
        }

        public async Task<Autenticacion> GetAutenticacion(string usuario, string contrasena)
        {
            
            var documen =  await _collection.FindAsync(new BsonDocument {{ "usuario", usuario }, { "contrasena", contrasena } }).Result.FirstAsync();

            Autenticacion autenticacion=new Autenticacion();

            autenticacion.Id = documen.Id;
            autenticacion.usuario = documen.usuario;
            autenticacion.contrasena = documen.contrasena;

            return autenticacion;
        }

        [HttpPost]
        public async Task InsertUsuario(Autenticacion autenticacion)
        {

            Cliente cliente = new Cliente();

            cliente.usuario = autenticacion.usuario;
            cliente.contrasena = autenticacion.contrasena;

            await _collection.InsertOneAsync(cliente);
        }
    }
}
