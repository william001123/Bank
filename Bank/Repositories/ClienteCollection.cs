using Bank.Models;
using Bank.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Bank.Repositories
{
    public class ClienteCollection : IClienteCollection
    {

        internal MongoDBRepository _repository = new MongoDBRepository();

        private IMongoCollection<Cliente> _collection;        

        public ClienteCollection()
        {
            _collection = _repository.db.GetCollection<Cliente>("Cliente");            
        }

        public async Task<Cliente> Get(string id)
        {

            var documet = await _collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
            return documet;
        }

        [HttpPost]
        public async Task Insert(Cliente entidad)
        {
            await _collection.InsertOneAsync(entidad);
        }

        public async Task Update(Cliente entidad)
        {
            var filter = Builders<Cliente>
                .Filter
                .Eq(s => s.Id, entidad.Id);

            // Crear el conjunto de actualización con el nuevo documento
            //var update = Builders<BsonDocument>.Update.Set("nombreCompleto", "Juan Guillermo Florez Gaviria")
            //                                          .Set("numeroIdentificacion", "321456987")
            //                                          .Set("direccion", "Calle 963, Envigado")
            //                                          .Set("telefono", "316-456-7890")
            //                                          .Set("correoElectronico", "jgflorezg@correo.iue.edu.co")
            //                                          .Set("informacionLaboral", "Docente")
            //                                          .Set("cuentas", new BsonArray
            //                                          {
            //                                          new BsonDocument
            //                                          {
            //                                              { "numeroCuenta", "147852369" },
            //                                              { "tipoCuenta", "Cuenta Corriente" },
            //                                              { "saldoActual", 1755650.00 },
            //                                              { "estadoCuenta", "Activo" }
            //                                          }
            //                                          })
            //                                          .Set("usuario", "JuanGui")
            //                                          .Set("contrasena", "1793");

            // Crear el conjunto de actualización con el nuevo documento
            var update = Builders<Cliente>.Update.Set("direccion", entidad.direccion)
                                                      .Set("telefono", entidad.telefono);

            //await _collection.ReplaceOneAsync(filter, entidad);
            await _collection.UpdateOneAsync(filter, update);
        }
    }
}
