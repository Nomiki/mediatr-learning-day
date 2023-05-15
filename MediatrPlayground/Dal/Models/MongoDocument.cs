using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MediatrPlayground.Dal.Models;

public abstract class MongoDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]
    [JsonIgnore]
    public ObjectId? ObjectId { get; set; }

    [BsonIgnore]
    public string Id => ObjectId?.ToString() ?? string.Empty;
}