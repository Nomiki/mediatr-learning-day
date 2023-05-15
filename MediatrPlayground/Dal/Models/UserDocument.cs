using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MediatrPlayground.Dal.Models;

public class UserDocument : MongoDocument
{
    public string? Name { get; set; }
}