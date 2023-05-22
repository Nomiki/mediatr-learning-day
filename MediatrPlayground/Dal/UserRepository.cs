using MediatrPlayground.Dal.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MediatrPlayground.Dal;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<UserDocument> _collection;

    public UserRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<UserDocument>("users");
    }
    
    public async Task<UserDocument?> GetUser(string userId)
    {
        var filter = Builders<UserDocument>.Filter.Eq(x => x.ObjectId, ObjectId.Parse(userId));
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }
    
    public async Task<UserDocument> PostUser(UserDocument user)
    {
        user.ObjectId = ObjectId.GenerateNewId();
        await _collection.InsertOneAsync(user);
        return user;
    }

    public async Task<UserDocument?> FindUserByName(string name)
    {
        var filter = Builders<UserDocument>.Filter.Eq(x => x.Name, name);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }
}