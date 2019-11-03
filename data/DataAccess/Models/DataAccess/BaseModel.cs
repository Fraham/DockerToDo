using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Models.DataAccess
{
    public abstract class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public override bool Equals(object obj)
        {
            return obj is BaseModel model &&
                   Id == model.Id &&
                   CreatedDate == model.CreatedDate &&
                   LastUpdatedDate == model.LastUpdatedDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CreatedDate, LastUpdatedDate);
        }
    }
}