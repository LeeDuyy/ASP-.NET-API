using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ASP_Web_Api.Models
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonRequired]
        public string? Id { get; set; }

        [BsonElement("username")]
        public string username { get; set; } = null!;

        [BsonElement("password")]
        public string password { get; set; } = null!;

        [BsonElement("role")]
        public string role { get; set; } = null!;
    }
}
