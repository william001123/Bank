using Bank.Models;
using MongoDB.Bson;

namespace Bank.Repositories.Interface
{
    public interface IAutenticacionCollection
    {
        Task InsertUsuario(Autenticacion autenticacion);
        Task<Autenticacion> GetAutenticacion(string usuario, string contrasena);
    }
}
