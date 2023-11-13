using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Bank.Models
{
    public class Cliente
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string? nombreCompleto { get; set; }
        public string? numeroIdentificacion { get; set; }
        public string? direccion { get; set; }
        public string? telefono { get; set; }
        public string? correoElectronico { get; set; }
        public string? informacionLaboral { get; set; }

        public List<cuentas> cuentas { get; set; }

        [BsonRequired]
        public string? usuario { get; set; }
        [BsonRequired]
        public string? contrasena { get; set; }

        public Cliente()
        {
            cuentas = new List<cuentas>();
        }

    }
}
