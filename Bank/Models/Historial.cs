using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Bank.Models
{
    public class Historial
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string? nombreCompleto { get; set; }
        public string? numeroIdentificacion { get; set; }

        public string? fechaHora { get; set; }

        public string? tipoTransaccion { get; set; }

        public int? monto { get; set; }
        public string? CuentaOrigen { get; set; }
        public string? CuentaDestino { get; set; }
        public string? descripcion { get; set; }

    }
}
