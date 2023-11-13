using Bank.Models;
using MongoDB.Bson;

namespace Bank.Repositories.Interface
{
    public interface IClienteCollection
    {
        Task Insert(Cliente entidad);
        Task<Cliente> Get(string id);
        Task Update(Cliente entidad);
    }
}
