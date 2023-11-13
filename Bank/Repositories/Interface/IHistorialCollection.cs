using Bank.Models;
using MongoDB.Bson;

namespace Bank.Repositories.Interface
{
    public interface IHistorialCollection
    {
        Task Insert(Historial entidad);
        Task<List<Historial>> Get(string CuentaOrigen);
    }
}
