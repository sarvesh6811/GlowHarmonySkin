using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace GlowHarmonySkin.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? OrderId { get; set; }
        public string? UserId { get; set; }
        public List<OrderItem>? Items { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Status { get; set; }
    }

    public class OrderItem
    {
        public string? ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
