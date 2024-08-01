using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GlowHarmonySkin.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
    }
}
