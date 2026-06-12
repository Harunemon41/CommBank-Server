using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CommBank.Models
{
    public class Goal
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? Name { get; set; }

        public DateTime TargetDate { get; set; }

        public double TargetAmount { get; set; }

        public double Balance { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string>? TransactionIds { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string>? TagIds { get; set; }

        // Optional Icon field added for Task 1
        public string? Icon { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }
    }
}
