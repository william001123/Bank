using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bank.Models
{
    public class Autenticacion
    {

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonRequired]
        public string? usuario { get; set; }
        [BsonRequired]
        public string? contrasena { get; set; }
    }
}
